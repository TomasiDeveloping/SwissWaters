using AutoMapper;
using Core.DataTransferObjects;
using Core.Helper;
using Core.Interfaces;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApiKeyService _apiKeyService;
    private readonly IMapper _mapper;
    private readonly SwissWatersContext _context;

    public UserRepository(SwissWatersContext context, IApiKeyService apiKeyService, IMapper mapper)
    {
        _context = context;
        _apiKeyService = apiKeyService;
        _mapper = mapper;
    }

    public async Task<ApiUserDto> CreateApiUserAsync(CreateUserDto createUserDto)
    {
        var password = PasswordService.CreateNewPassword(createUserDto.Password);
        var user = new ApiUser
        {
            Id = Guid.NewGuid(),
            Email = createUserDto.Email,
            OwnerName = $"{createUserDto.FirstName} - {createUserDto.LastName}",
            ApiKey = _apiKeyService.GenerateApiKey(),
            UserClaims = new List<UserClaim> {new() {Name = "Customer"}},
            Password = password.PasswordHash,
            Salt = password.PasswordSalt
        };

        await _context.ApiUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<ApiUserDto>(user);
    }

    public async Task<ApiUser?> GetApiUserByApiKeyAsync(string apiKey)
    {
        var apiUser = await _context.ApiUsers
            .Include(u => u.UserClaims)
            .FirstOrDefaultAsync(u => u.ApiKey == apiKey);
        return apiUser;
    }

    public async Task<ApiUser?> GetUserForLoginByEmailAsync(string email)
    {
        return await _context.ApiUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(au => au.Email.Equals(email));
    }
}