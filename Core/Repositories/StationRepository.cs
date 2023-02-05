using AutoMapper;
using Core.DataTransferObjects;
using Core.Interfaces;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class StationRepository : IStationRepository
{
    private readonly SwissWatersContext _context;
    private readonly IMapper _mapper;
    private readonly DateTime _currentDate;

    public StationRepository(SwissWatersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _currentDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
    }

    public async Task<List<StationDto>> GetStationsWithCantonsOnlyAsync()
    {
        var stations = await _context.Stations
            .Include(s => s.CantonStations)
            .ThenInclude(cs => cs.Canton)
            .OrderBy(s => s.WatersName)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<StationDto>>(stations);
    }

    public async Task<StationDto?> GetStationByNameAndWatersNameAsync(string stationName, string watersName)
    {
        var station = await _context.Stations
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Name.Contains(stationName) && s.WatersName.Contains(watersName));
        return station == null ? null : _mapper.Map<StationDto>(station);
    }

    public async Task<List<StationDto>> GetStationsByWatersNameAsync(string watersName)
    {
        var stations = await _context.Stations
            .AsNoTracking()
            .Where(s => s.WatersName.Contains(watersName))
            .ToListAsync();
        return _mapper.Map<List<StationDto>>(stations);
    }


    public async Task<List<StationDto>> GetLatestMeasurementAsync()
    {
        var stations = await _context.Stations
            .Include(s => s.WatersType)
            .Include(s => s.StationAbilities)
            .ThenInclude(sa => sa.Measurements
                .OrderByDescending(m => m.MeasurementTime).Take(1))
            .Include(s => s.CantonStations)
            .ThenInclude(cs => cs.Canton)
            .OrderBy(s => s.WatersName)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<StationDto>>(stations);
    }

    public async Task<StationDto?> GetStationByStationIdAsync(string stationId, int dayIncluded)
    {
        var station = await _context.Stations
            .Include(s => s.WatersType)
            .Include(s => s.StationAbilities)
            .ThenInclude(sa => sa.Measurements
                .OrderByDescending(m => m.MeasurementTime)
                .Where(m => m.MeasurementTime >= _currentDate.AddDays(- dayIncluded)))
            .OrderBy(s => s.WatersName)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id.ToString() == stationId);
        return station == null ? null : _mapper.Map<StationDto>(station);
    }

    public async Task<List<StationDto>> GetStationsByCantonNameAsync(string cantonName, int dayIncluded)
    {
        var stations = await _context.Stations
            .Include(s => s.WatersType)
            .Include(s => s.StationAbilities)
            .ThenInclude(sa => sa.Measurements
                .OrderByDescending(m => m.MeasurementTime)
                .Where(m => m.MeasurementTime >= _currentDate.AddDays(-dayIncluded)))
            .AsNoTracking()
            .OrderBy(s => s.WatersName)
            .Where(s => s.CantonStations.Any(cs => cs.Canton.Name.Equals(cantonName)))
            .ToListAsync();
        return _mapper.Map<List<StationDto>>(stations);
    }

    public async Task<List<StationDto>> GetStationsByCantonCodeAsync(string cantonCode, int dayIncluded)
    {
        var stations = await _context.Stations
            .Include(s => s.WatersType)
            .Include(s => s.StationAbilities)
            .ThenInclude(sa => sa.Measurements
                .OrderByDescending(m => m.MeasurementTime)
                .Where(m => m.MeasurementTime >= _currentDate.AddDays(-dayIncluded)))
            .OrderBy(s => s.WatersName)
            .AsNoTracking()
            .Where(s => s.CantonStations.Any(cs => cs.Canton.Code.Equals(cantonCode)))
            .ToListAsync();
        return _mapper.Map<List<StationDto>>(stations);
    }

    public async Task<StationDto> InsertStationAsync(StationDto stationDto)
    {
        var station = _mapper.Map<Station>(stationDto);
        await _context.Stations.AddAsync(station);
        await _context.SaveChangesAsync();
        return _mapper.Map<StationDto>(station);
    }

    public async Task<bool> UpdateStationAsync(StationDto stationDto)
    {
        var stationToUpdate = await _context.Stations.FirstOrDefaultAsync(s => s.Id == stationDto.Id);
        if (stationToUpdate == null) throw new ArgumentException($"Station with id {stationDto.Id} not found");

        stationToUpdate.Name = stationDto.Name;
        stationToUpdate.Northing = stationDto.Northing;
        stationToUpdate.Easting = stationDto.Easting;
        await _context.SaveChangesAsync();
        return true;
    }
}