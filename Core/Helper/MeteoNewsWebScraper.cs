using System.Globalization;
using System.Net;
using Core.DataTransferObjects;
using Core.Interfaces;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;

namespace Core.Helper;

public class MeteoNewsWebScraper
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly string _meteoNewsTemperatureUrl;
    private readonly IStationAbilityRepository _stationAbilityRepository;
    private readonly IStationRepository _stationRepository;
    private readonly IWatersTypeRepository _watersTypeRepository;

    public MeteoNewsWebScraper(IConfiguration configuration, IMeasurementRepository measurementRepository,
        IStationAbilityRepository stationAbilityRepository, IStationRepository stationRepository,
        IWatersTypeRepository watersTypeRepository)
    {
        _measurementRepository = measurementRepository;
        _stationAbilityRepository = stationAbilityRepository;
        _stationRepository = stationRepository;
        _watersTypeRepository = watersTypeRepository;
        _meteoNewsTemperatureUrl = configuration.GetValue<string>("MeteoNewsTemperatureUrl");
    }

    public static async Task<string> CallUrl(string uri)
    {
        try
        {
            var client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetStringAsync(uri);
            return WebUtility.HtmlDecode(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> GetMetoNewsWatersTemperatures()
    {
        try
        {
            var htmlDoc = new HtmlDocument();
            var htmlResponseString = await CallUrl(_meteoNewsTemperatureUrl);
            htmlDoc.LoadHtml(htmlResponseString);
            var lakeTables = htmlDoc.DocumentNode.Descendants("tr").ToList();

            foreach (var lakeTable in lakeTables)
            {
                var lakes = lakeTable.Descendants("td").ToList();

                if (!lakes.Any()) continue;

                var lakeName = lakes[0].InnerText.Trim();
                var lakeTemperatureString = lakes[1].InnerText.Trim();
                if (lakeName.StartsWith("Vierwald")) lakeName = "Vierwaldstättersee";
                if (lakeName.Equals("Ägerisee")) lakeName = "Aegerisee";
                if (lakeName.Equals("Genfersee")) lakeName = "Lac Léman";
                if (lakeName.Equals("Luganersee")) lakeName = "Lago di Lugano";
                if (lakeName.Equals("Neuenburgersee")) lakeName = "Lac de Neuchâtel";

                var stations = await GetOrCreateStationsAsync(lakeName);

                foreach (var station in stations)
                {
                    decimal? lakeTemperature = string.IsNullOrEmpty(lakeTemperatureString)
                        ? null
                        : decimal.Parse(lakeTemperatureString.Replace("°C", ""), CultureInfo.InvariantCulture);
                    if (lakeTemperature == null) continue;

                    var stationAbilityDto = await GetOrCreateStationAbilityAsync(station.Id);

                    await CreateMeasurement(stationAbilityDto.Id, lakeTemperature.Value);
                }
            }

            return true;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    private async Task<List<StationDto>> GetOrCreateStationsAsync(string watersName)
    {
        var stations = await _stationRepository.GetStationsByWatersNameAsync(watersName);
        if (stations.Any()) return stations;

        var waterTypeId = await _watersTypeRepository.GetWatersTypeIdByIdentifierAsync("LAKE");
        if (waterTypeId == null) throw new ArgumentException("No WaterType found");
        var newStation = new StationDto
        {
            Name = "-",
            WatersName = watersName,
            Easting = 0,
            Northing = 0,
            WatersTypeName = waterTypeId.ToString()
        };
        stations.Add(await _stationRepository.InsertStationAsync(newStation));
        return stations;
    }

    private async Task<StationAbilityDto> GetOrCreateStationAbilityAsync(Guid stationId)
    {
        var stationAbilityDto =
            await _stationAbilityRepository.GetStationAbilityByNameAndStationIdAsync("Wassertemperatur",
                stationId);
        if (stationAbilityDto != null) return stationAbilityDto;

        var newStationAbility = new StationAbilityDto
        {
            Name = "Wassertemperatur",
            StationId = stationId,
            Unit = "°C"
        };
        stationAbilityDto =
            await _stationAbilityRepository.InsertStationAbilityAsync(newStationAbility);
        return stationAbilityDto;
    }

    private async Task CreateMeasurement(Guid stationAbilityId, decimal lakeTemperature)
    {
        var measurementDto =
            await _measurementRepository.GetLatestMeasurementByStationAbilityIdAsync(stationAbilityId);
        if (measurementDto == null)
        {
            var newMeasurement = new MeasurementDto
            {
                Value = lakeTemperature,
                StationAbilityId = stationAbilityId,
                Max24H = null,
                Mean24H = null,
                Min24H = null,
                MeasurementTime = DateTime.Now
            };
            await _measurementRepository.InsertMeasurementAsync(newMeasurement);
        }
        else
        {
            if (measurementDto.MeasurementTime.Day == DateTime.Now.Day &&
                measurementDto.MeasurementTime.Month == DateTime.Now.Month &&
                measurementDto.Value == lakeTemperature) return;

            var newMeasurement = new MeasurementDto
            {
                Max24H = null,
                Mean24H = null,
                Min24H = null,
                Value = lakeTemperature,
                MeasurementTime = DateTime.Now,
                StationAbilityId = stationAbilityId
            };
            await _measurementRepository.InsertMeasurementAsync(newMeasurement);
        }
    }
}