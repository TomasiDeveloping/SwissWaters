using Core.DataTransferObjects;

namespace Core.Interfaces;

public interface IStationRepository
{
    Task<List<StationDto>> GetStationsWithCantonsOnlyAsync();
    Task<StationDto?> GetStationByNameAndWatersNameAsync(string stationName, string watersName);
    Task<List<StationDto>> GetStationsByWatersNameAsync(string watersName);
    Task<List<StationDto>> GetLatestMeasurementAsync();
    Task<StationDto?> GetStationByStationIdAsync(string stationId, int dayIncluded);
    Task<List<StationDto>> GetStationsByCantonNameAsync(string cantonName, int dayIncluded);
    Task<List<StationDto>> GetStationsByCantonCodeAsync(string cantonCode, int dayIncluded);
    Task<StationDto> InsertStationAsync(StationDto stationDto);
    Task<bool> UpdateStationAsync(StationDto stationDto);
}