using AutoMapper;
using Core.DataTransferObjects;
using Core.Interfaces;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class StationAbilityRepository : IStationAbilityRepository
{
    private readonly SwissWatersContext _context;
    private readonly IMapper _mapper;

    public StationAbilityRepository(SwissWatersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StationAbility?> GetStationAbilityByStationIdAsync(Guid stationsId)
    {
        var stationAbility = await _context.StationAbilities.FirstOrDefaultAsync(sa => sa.Id == stationsId);
        return stationAbility;
    }

    public async Task<StationAbilityDto?> GetStationAbilityByNameAndStationIdAsync(string stationAbilityName,
        Guid stationId)
    {
        var stationAbility =
            await _context.StationAbilities.FirstOrDefaultAsync(sa =>
                sa.Name.Contains(stationAbilityName) && sa.StationId == stationId);
        return stationAbility == null ? null : _mapper.Map<StationAbilityDto>(stationAbility);
    }

    public async Task<StationAbilityDto> InsertStationAbilityAsync(StationAbilityDto stationAbilityDto)
    {
        var stationAbility = _mapper.Map<StationAbility>(stationAbilityDto);
        await _context.StationAbilities.AddAsync(stationAbility);
        await _context.SaveChangesAsync();
        return _mapper.Map<StationAbilityDto>(stationAbility);
    }
}