using System.Security.Claims;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories;

public class ApiKeyRepository : IApiKeyRepository
{
    private readonly IUserRepository _userRepository;

    public ApiKeyRepository(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ApiKey?> GetApiKeyAsync(string apiKey)
    {
        var apiUser = await _userRepository.GetApiUserByApiKeyAsync(apiKey);
        if (apiUser == null) return null;
        var userClaims = apiUser.UserClaims.Select(userClaim => new Claim(ClaimTypes.Role, userClaim.Name)).ToList();
        return new ApiKey(apiKey, apiUser.OwnerName, userClaims);
    }
}