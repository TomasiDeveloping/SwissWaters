using AutoMapper;
using Core.DataTransferObjects;
using Core.Interfaces;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class MeasurementRepository : IMeasurementRepository
{
    private readonly SwissWatersContext _context;
    private readonly IMapper _mapper;

    public MeasurementRepository(SwissWatersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MeasurementDto?> GetLatestMeasurementByStationAbilityIdAsync(Guid stationAbilityId)
    {
        var measurement = await _context.Measurements
            .OrderByDescending(m => m.MeasurementTime)
            .FirstOrDefaultAsync(m => m.StationAbilityId == stationAbilityId);
        return measurement == null ? null : _mapper.Map<MeasurementDto>(measurement);
    }

    public async Task<MeasurementDto?> GetMeasurementByIdAsync(Guid measurementId)
    {
        var measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == measurementId);
        return measurement == null ? null : _mapper.Map<MeasurementDto>(measurement);
    }

    public async Task<MeasurementDto?> GetLatestStationAbilityValueAsync(Guid stationAbilityId)
    {
        var measurement = await _context.Measurements
            .OrderByDescending(m => m.MeasurementTime)
            .FirstOrDefaultAsync(m => m.StationAbilityId == stationAbilityId);
        return measurement == null ? null : _mapper.Map<MeasurementDto>(measurement);
    }

    public async Task<MeasurementDto> InsertMeasurementAsync(MeasurementDto measurementDto)
    {
        var newMeasurement = _mapper.Map<Measurement>(measurementDto);
        await _context.Measurements.AddAsync(newMeasurement);
        await _context.SaveChangesAsync();
        return _mapper.Map<MeasurementDto>(newMeasurement);
    }
}