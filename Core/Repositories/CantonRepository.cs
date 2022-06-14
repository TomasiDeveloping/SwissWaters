using AutoMapper;
using Core.DataTransferObjects;
using Core.Interfaces;
using Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class CantonRepository : ICantonRepository
{
    private readonly SwissWatersContext _context;
    private readonly IMapper _mapper;

    public CantonRepository(SwissWatersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CantonDto>> GetCantonsAsync()
    {
        var cantons = await _context.Cantons
            .OrderBy(c => c.Name)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<CantonDto>>(cantons);
    }
}