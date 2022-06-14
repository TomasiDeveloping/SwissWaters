using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class CantonsController : ControllerBase
{
    private readonly ICantonRepository _cantonRepository;
    private readonly ILogger<CantonsController> _logger;

    public CantonsController(ICantonRepository cantonRepository, ILogger<CantonsController> logger)
    {
        _cantonRepository = cantonRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var cantons = await _cantonRepository.GetCantonsAsync();
            return Ok(cantons);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}