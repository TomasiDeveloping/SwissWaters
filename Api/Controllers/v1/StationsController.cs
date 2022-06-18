using Core.DataTransferObjects;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Api.Controllers.v1;

[Authorize]
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

    /// <summary>
    /// Get a station by id
    /// </summary>
    /// <param name="stationId"></param>
    /// <param name="dayIncluded"></param>
    /// <response code="200">Returns the station</response>
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StationDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Get Current measured values
    /// </summary>
    /// <response code="200">Returns a list with all stations and the current measured values</response>
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StationDto>))]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
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

    /// <summary>
    /// Get all stations by canton code
    /// </summary>
    /// <param name="cantonCode"></param>
    /// <param name="dayIncluded"></param>
    /// <response code="200">Returns a list with all stations for the canton code</response>
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StationDto>))]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetStationsByCantonCode([FromQuery] string cantonCode, int dayIncluded = 1)
    {
        try
        {
            var stations = await _stationRepository.GetStationsByCantonCodeAsync(cantonCode, dayIncluded);
            if (!stations.Any()) return NoContent();
            return Ok(stations);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Get all Stations by canton name
    /// </summary>
    /// <param name="cantonName"></param>
    /// <param name="dayIncluded"></param>
    /// <response code="200">Returns a list with all stations for the canton name</response>
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StationDto>))]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
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