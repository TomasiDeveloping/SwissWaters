using Core.DataTransferObjects;
using GrpcService.Protos;

namespace GrpcService.Helpers;

public interface ICustomStationMapper
{
    StationsModel? MapFromStationDto(StationDto stationDto);
}