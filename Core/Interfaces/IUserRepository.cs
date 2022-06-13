using Core.DataTransferObjects;
using Database.Entities;

namespace Core.Interfaces;

public interface IUserRepository
{
    Task<string> CreateApiUserAsync(CreateUserDto createUserDto);
    Task<ApiUser?> GetApiUserByApiKeyAsync(string apiKey);
}