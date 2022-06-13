using Core.DataTransferObjects;
using Core.Interfaces;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApiKeyService _apiKeyService;
    private readonly SwissWatersContext _context;

    public UserRepository(SwissWatersContext context, IApiKeyService apiKeyService)
    {
        _context = context;
        _apiKeyService = apiKeyService;
    }

    public async Task<string> CreateApiUserAsync(CreateUserDto createUserDto)
    {
        var user = new ApiUser
        {
            Id = Guid.NewGuid(),
            Email = createUserDto.Email,
            OwnerName = $"{createUserDto.FirstName} - {createUserDto.LastName}",
            ApiKey = _apiKeyService.GenerateApiKey(),
            UserClaims = new List<UserClaim> {new() {Name = "Customer"}}
        };

        await _context.ApiUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.ApiKey;
    }

    public async Task<ApiUser?> GetApiUserByApiKeyAsync(string apiKey)
    {
        var apiUser = await _context.ApiUsers
            .Include(u => u.UserClaims)
            .FirstOrDefaultAsync(u => u.ApiKey == apiKey);
        return apiUser;
    }
}