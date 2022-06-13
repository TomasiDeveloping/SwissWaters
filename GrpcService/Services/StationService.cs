using Core.Interfaces;
using Grpc.Core;
using GrpcService.Helpers;
using GrpcService.Protos;

namespace GrpcService.Services;

public class StationService : Protos.StationService.StationServiceBase
{
    private readonly ICustomStationMapper _customStationMapper;
    private readonly IStationRepository _stationRepository;

    public StationService(IStationRepository stationRepository, ICustomStationMapper customStationMapper)
    {
        _stationRepository = stationRepository;
        _customStationMapper = customStationMapper;
    }

    public override async Task GetAllWaters(GetEmptyRequest request, IServerStreamWriter<StationsModel> responseStream,
        ServerCallContext context)
    {
        var stations = await _stationRepository.GetLatestMeasurementAsync();

        foreach (var station in stations)
        {
            var stationModel = _customStationMapper.MapFromStationDto(station);
            if (stationModel == null) continue;
            await responseStream.WriteAsync(stationModel);
        }
    }
}