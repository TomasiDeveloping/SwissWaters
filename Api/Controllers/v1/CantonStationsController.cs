using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class CantonStationsController : ControllerBase
{
    private readonly ICantonStationRepository _cantonStationRepository;
    private readonly ILogger<CantonStationsController> _logger;

    public CantonStationsController(ICantonStationRepository cantonStationRepository,
        ILogger<CantonStationsController> logger)
    {
        _cantonStationRepository = cantonStationRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CantonStationRequest cantonStationRequest)
    {
        try
        {
            var check = await _cantonStationRepository.InsertCantonStationAsync(cantonStationRequest);
            return Ok(check);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}