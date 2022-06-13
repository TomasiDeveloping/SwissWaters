using Core.DataTransferObjects;

namespace Core.Interfaces;

public interface IStationRepository
{
    Task<StationDto?> GetStationByNameAsync(string stationName, string watersName);
    Task<List<StationDto>> GetStationsByWatersNameAsync(string watersName);
    Task<List<StationDto>> GetLatestMeasurementAsync();
    Task<StationDto> InsertStationAsync(StationDto stationDto);
    Task<bool> UpdateStationAsync(StationDto stationDto);
}