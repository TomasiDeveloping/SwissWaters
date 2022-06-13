using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class MeteoNewsController : ControllerBase
{
    private readonly ILogger<MeteoNewsController> _logger;
    private readonly MeteoNewsWebScraper _meteoNewsWebScraper;

    public MeteoNewsController(IConfiguration configuration, IMeasurementRepository measurementRepository,
        IStationAbilityRepository stationAbilityRepository, IStationRepository stationRepository,
        IWatersTypeRepository watersTypeRepository, ILogger<MeteoNewsController> logger)
    {
        _logger = logger;
        _meteoNewsWebScraper = new MeteoNewsWebScraper(configuration, measurementRepository,
            stationAbilityRepository, stationRepository, watersTypeRepository);
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetWatersTemperatures()
    {
        try
        {
            var check = await _meteoNewsWebScraper.GetMetoNewsWatersTemperatures();
            return check ? Ok(check) : BadRequest("Error");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}