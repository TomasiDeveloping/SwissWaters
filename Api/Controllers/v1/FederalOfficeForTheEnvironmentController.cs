using System.Diagnostics;
using Core.Helper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class FederalOfficeForTheEnvironmentController : ControllerBase
{
    private readonly ILogger<FederalOfficeForTheEnvironmentController> _logger;
    private readonly FederalOfficeForTheEnvironment _federalOfficeForEnvironment;

    public FederalOfficeForTheEnvironmentController(IStationRepository stationRepository,
        IStationAbilityRepository stationAbilityRepository, IMeasurementRepository measurementRepository,IConfiguration configuration,
        IWatersTypeRepository watersTypeRepository, ILogger<FederalOfficeForTheEnvironmentController> logger)
    {
        _logger = logger;
        _federalOfficeForEnvironment = new FederalOfficeForTheEnvironment(stationRepository, stationAbilityRepository,
            measurementRepository, watersTypeRepository, configuration);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var timer = new Stopwatch();
            timer.Start();
            var check = await _federalOfficeForEnvironment.GetData();
            timer.Stop();
            var timeTaken = timer.Elapsed;
            _logger.LogInformation($"Time taken: {timeTaken:m\\:ss\\.fff}");
            return check ? Ok() : BadRequest("Error");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}