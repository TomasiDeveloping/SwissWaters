using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class StationsController : ControllerBase
{
    private readonly IStationRepository _stationRepository;
    private readonly ILogger<StationsController> _logger;

    public StationsController(IStationRepository stationRepository, ILogger<StationsController> logger)
    {
        _stationRepository = stationRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var stations = await _stationRepository.GetLatestMeasurementAsync();
            if (!stations.Any()) return NoContent();
            return Ok(stations);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}