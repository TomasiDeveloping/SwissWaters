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
            var stations = await _stationRepository.GetStationsWithCantonsOnlyAsync();
            return Ok(stations);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{stationId}")]
    public async Task<IActionResult> Get(string stationId, int dayIncluded = 1)
    {
        try
        {
            var station = await _stationRepository.GetStationByStationIdAsync(stationId, dayIncluded);
            if (station == null) return NotFound($"No station with id {stationId} found");
            return Ok(station);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetLatestMeasurements()
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

    [HttpGet("[action]")]
    public async Task<IActionResult> GetStationsByCantonCode([FromQuery] string cantonCode, int dayIncluded = 1)
    {
        try
        {
            var stations = await _stationRepository.GetStationsByCantonCodeAsync(cantonCode, dayIncluded);
            return Ok(stations);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetStationsByCantonName([FromQuery] string cantonName, int dayIncluded = 1)
    {
        try
        {
            var stations = await _stationRepository.GetStationsByCantonNameAsync(cantonName, dayIncluded);
            return Ok(stations);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}