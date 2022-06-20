using Core.DataTransferObjects;
using Database.Entities;

namespace Core.Interfaces;

public interface IUserRepository
{
    Task<ApiUserDto> CreateApiUserAsync(CreateUserDto createUserDto);
    Task<ApiUser?> GetApiUserByApiKeyAsync(string apiKey);
    Task<ApiUser?> GetUserForLoginByEmailAsync(string email);
}