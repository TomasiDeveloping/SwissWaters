﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Check status of the API
    /// </summary>
    /// <response code="200">Returns a string</response>
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok("API is running...");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
}