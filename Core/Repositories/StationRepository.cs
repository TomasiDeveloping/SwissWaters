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

    public StationRepository(SwissWatersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StationDto?> GetStationByNameAsync(string stationName, string watersName)
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
            .Include(s => s.SensorAbilities)
            .ThenInclude(sa => sa.Measurements.OrderByDescending(m => m.MeasurementTime).Take(1))
            .AsNoTracking()
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