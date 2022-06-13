using Core.DataTransferObjects;
using Google.Protobuf.WellKnownTypes;
using GrpcService.Protos;

namespace GrpcService.Helpers;

public class CustomStationMapper : ICustomStationMapper
{
    public StationsModel MapFromStationDto(StationDto stationDto)
    {
        var stationAbilityModels = (from stationAbility in stationDto.SensorAbilities
            let measurementModels = stationAbility.Measurements.Select(measurement => new MeasurementModel
                {
                    Id = measurement.Id.ToString(),
                    Value = (double) measurement.Value,
                    Max24H = (double) measurement.Max24H,
                    Min24H = (double) measurement.Min24H,
                    Mean24H = (double) measurement.Mean24H,
                    StationAbilityId = measurement.StationAbilityId.ToString(),
                    MeasurementTime = Timestamp.FromDateTimeOffset(measurement.MeasurementTime)
                })
                .ToList()
            select new StationAbilityModel
            {
                Id = stationAbility.Id.ToString(),
                Name = stationAbility.Name,
                StationId = stationAbility.StationId.ToString(),
                Unit = stationAbility.Unit,
                MeasurementModel = {measurementModels}
            }).ToList();

        return new StationsModel
        {
            Id = stationDto.Id.ToString(),
            Easting = stationDto.Easting,
            Name = stationDto.Name,
            WatersName = stationDto.WatersName,
            WatersTypeName = stationDto.WatersTypeName,
            Northing = stationDto.Northing,
            StationAbilityModel = {stationAbilityModels}
        };
    }
}