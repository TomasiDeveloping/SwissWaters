using Core.DataTransferObjects;
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
}