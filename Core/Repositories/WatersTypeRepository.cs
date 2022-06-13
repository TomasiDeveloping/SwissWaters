using Core.Interfaces;
using Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class WatersTypeRepository : IWatersTypeRepository
{
    private readonly SwissWatersContext _context;

    public WatersTypeRepository(SwissWatersContext context)
    {
        _context = context;
    }

    public async Task<Guid?> GetWatersTypeIdByIdentifierAsync(string identifier)
    {
        var watersType = await _context.WatersTypes.FirstOrDefaultAsync(wt => wt.Identifier == identifier.ToUpper());
        return watersType?.Id;
    }
}