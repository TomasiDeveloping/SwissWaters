using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using Core.DataTransferObjects;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Core.Helper;

public class FederalOfficeForTheEnvironment
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IWatersTypeRepository _watersTypeRepository;
    private readonly IStationAbilityRepository _stationAbilityRepository;
    private readonly IStationRepository _stationRepository;
    private readonly string _bafuUserName;
    private readonly string _bafuPassword;
    private readonly string _bafuApiUrl;

    public FederalOfficeForTheEnvironment(IStationRepository stationRepository,
        IStationAbilityRepository stationAbilityRepository, IMeasurementRepository measurementRepository, IWatersTypeRepository watersTypeRepository, IConfiguration configuration)
    {
        _stationRepository = stationRepository;
        _stationAbilityRepository = stationAbilityRepository;
        _measurementRepository = measurementRepository;
        _watersTypeRepository = watersTypeRepository;
        _bafuUserName = configuration.GetValue<string>("BafuUserName");
        _bafuPassword = configuration.GetValue<string>("BafuPassword");
        _bafuApiUrl = configuration.GetValue<string>("BafuApiUrl");
    }

    public async Task<bool> GetData()
    {
        var authToken = Encoding.ASCII.GetBytes($"{_bafuUserName}:{_bafuPassword}");

        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(authToken));
            var response = await client.GetAsync(_bafuApiUrl);

            if (!response.IsSuccessStatusCode) throw new ArgumentException("Get request no success status");
            var resultContent = await response.Content.ReadAsStringAsync();

            var xml = new XmlDocument();
            xml.LoadXml(resultContent);

            var check = await ProcessXml(xml);

            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    private async Task<bool> ProcessXml(XmlDocument xmlDocument)
    {
        var xmlStations = xmlDocument.SelectNodes("locations/station");

        if (xmlStations == null) return true;
        foreach (XmlNode xmlStation in xmlStations)
        {
            var stationDto = await GetAndCreateStation(xmlStation);

            var xmlStationAbilities = xmlStation.SelectNodes("parameter");
            if (xmlStationAbilities == null) continue;

            foreach (XmlNode xmlStationAbility in xmlStationAbilities)
            {

                var stationAbilityDto = await GetOrCreateStationAbilityAsync(xmlStationAbility, stationDto.Id);
                await InsertMeasurementAsync(xmlStationAbility, stationAbilityDto.Id);
            }
        }

        return true;
    }

    private async Task<StationDto> GetAndCreateStation(XmlNode xmlStation)
    {
        var name = xmlStation.Attributes?["name"]?.Value;
        var watersName = xmlStation.Attributes?["water-body-name"]?.Value;
        var watersTypeName = xmlStation.Attributes?["water-body-type"]?.Value;
        var waterTypeId = await GetOrCreateWatersType(watersTypeName);
        if (string.IsNullOrEmpty(watersName) || string.IsNullOrEmpty(name))
            throw new ArgumentException("name or water-body-name is empty");
        var stationDto = await _stationRepository.GetStationByNameAndWatersNameAsync(name, watersName);
        if (stationDto != null) return stationDto;

        var easting = xmlStation.Attributes?["easting"]?.Value;
        var northing = xmlStation.Attributes?["northing"]?.Value;
        if (easting == null || northing == null) throw new ArgumentException("No easting or northing in XML");
        var newStation = new StationDto
        {
            Easting = int.Parse(easting),
            Northing = int.Parse(northing),
            Name = name,
            WatersName = watersName,
            WatersTypeName = waterTypeId.ToString()
        };
        stationDto = await _stationRepository.InsertStationAsync(newStation);
        return stationDto;
    }

    private async Task<Guid> GetOrCreateWatersType(string watersTypeName)
    {
        var waterTypeId = await _watersTypeRepository.GetWatersTypeIdByIdentifierAsync(watersTypeName);
        if (waterTypeId == null) throw new ArgumentException($"Unknown WatersType {watersTypeName}");
        return waterTypeId.Value;
    }

    private async Task<StationAbilityDto> GetOrCreateStationAbilityAsync(XmlNode xmlStationAbility, Guid stationId)
    {
        var stationAbilityName = xmlStationAbility.Attributes?["name"]?.Value;
        var stationAbilityDto =
            await _stationAbilityRepository.GetStationAbilityByNameAndStationIdAsync(stationAbilityName, stationId);
        if (stationAbilityDto != null) return stationAbilityDto;

        var unit = xmlStationAbility.Attributes?["unit"]?.Value;
        var newStationAbility = new StationAbilityDto
        {
            Name = stationAbilityName,
            Unit = unit,
            StationId = stationId
        };
        stationAbilityDto = await _stationAbilityRepository.InsertStationAbilityAsync(newStationAbility);
        return stationAbilityDto;
    }

    private async Task InsertMeasurementAsync(XmlNode xmlStationAbility, Guid stationAbilityId)
    {
        var datetime = DateTime.Parse(xmlStationAbility.SelectSingleNode("datetime").InnerText);
        var value = decimal.Parse(xmlStationAbility.SelectSingleNode("value").InnerText);
        var max24H = decimal.Parse(xmlStationAbility.SelectSingleNode("max-24h").InnerText);
        var mean24H = decimal.Parse(xmlStationAbility.SelectSingleNode("mean-24h").InnerText);
        var min24H = decimal.Parse(xmlStationAbility.SelectSingleNode("min-24h").InnerText);
        var latestMeasurement = await _measurementRepository.GetLatestMeasurementByStationAbilityIdAsync(stationAbilityId);
        if (latestMeasurement != null)
        {
            if (latestMeasurement.MeasurementTime.Day == datetime.Day && 
                latestMeasurement.MeasurementTime.Hour == datetime.Hour && 
                latestMeasurement.MeasurementTime.Minute == datetime.Minute) 
                return;
        }
       
        var measurement = new MeasurementDto
        {
            Value = value,
            Max24H = max24H,
            Mean24H = mean24H,
            Min24H = min24H,
            MeasurementTime = datetime,
            StationAbilityId = stationAbilityId
        };
        await _measurementRepository.InsertMeasurementAsync(measurement);
    }
}