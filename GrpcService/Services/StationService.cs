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


    public override async Task GetLatestMeasurements(GetEmptyRequest request,
        IServerStreamWriter<StationsModel> responseStream, ServerCallContext context)
    {
        var stations = await _stationRepository.GetLatestMeasurementAsync();

        foreach (var station in stations)
        {
            var stationModel = _customStationMapper.MapFromStationDto(station);
            if (stationModel == null) continue;
            await responseStream.WriteAsync(stationModel);
        }
    }

    public override async Task<StationsModel> GetStationById(GetStationRequest request, ServerCallContext context)
    {
        var dayIncluded = request.DayIncluded ?? 7;

        var station = await _stationRepository.GetStationByStationIdAsync(request.Id, dayIncluded);

        if (station == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"No station with id: {request.Id} found"));
        return _customStationMapper.MapFromStationDto(station);
    }

    public override async Task GetStationsByCantonCode(GetStationByCantonCodeRequest request, IServerStreamWriter<StationsModel> responseStream,
        ServerCallContext context)
    {
        var dayIncluded = request.DayIncluded ?? 7;

        var stations = await _stationRepository.GetStationsByCantonCodeAsync(request.CantonCode, dayIncluded);

        foreach (var station in stations)
        {
            var stationModel = _customStationMapper.MapFromStationDto(station);
            await responseStream.WriteAsync(stationModel);
        }
    }

    public override async Task GetStationsByCantonName(GetStationByCantonNameRequest request, IServerStreamWriter<StationsModel> responseStream,
        ServerCallContext context)
    {
        var dayIncluded = request.DayIncluded ?? 7;

        var stations = await _stationRepository.GetStationsByCantonNameAsync(request.CantonName, dayIncluded);

        foreach (var station in stations)
        {
            var stationModel = _customStationMapper.MapFromStationDto(station);
            await responseStream.WriteAsync(stationModel);
        }
    }
}