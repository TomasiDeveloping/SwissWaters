using Core.Interfaces;
using Core.Models;
using Database.Data;
using Database.Entities;

namespace Core.Repositories;

public class CantonStationRepository : ICantonStationRepository
{
    private readonly SwissWatersContext _context;

    public CantonStationRepository(SwissWatersContext context)
    {
        _context = context;
    }

    public async Task<bool> InsertCantonStationAsync(CantonStationRequest cantonStationRequest)
    {
        var cantonStation = new CantonStation
        {
            CantonId = new Guid(cantonStationRequest.CantonId),
            StationId = new Guid(cantonStationRequest.StationId)
        };
        await _context.CantonStations.AddAsync(cantonStation);
        await _context.SaveChangesAsync();
        return true;
    }
}