using Core.DataTransferObjects;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class ApiUserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<ApiUserController> _logger;

    public ApiUserController(IUserRepository userRepository, ILogger<ApiUserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateApiUser(CreateUserDto createUserDto)
    {
        try
        {
            var apiKey = await _userRepository.CreateApiUserAsync(createUserDto);
            _logger.LogInformation($"New Api key created: {apiKey}");
            return Ok(apiKey);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<ActionResult<ApiUserDto>> Login(LoginDto loginDto)
    {
        try
        {
            var user = await _userRepository.GetUserForLoginByEmailAsync(loginDto.Email);
            if (user == null) return BadRequest("Login fehlgeschlagen");
            var verifyPassword = PasswordService.VerifyPassword(loginDto.Password, user.Password, user.Salt);
            if (!verifyPassword) return BadRequest("Login fehlgeschlagen");
            return Ok(new ApiUserDto
            {
                Email = user.Email,
                ApiKey = user.ApiKey,
                Id = user.Id,
                OwnerName = user.OwnerName
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest("Login failed");
        }
    }

}