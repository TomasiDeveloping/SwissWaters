using Core.Models;

namespace Core.Interfaces;

public interface IApiKeyRepository
{
    Task<ApiKey?> GetApiKeyAsync(string apiKey);
}