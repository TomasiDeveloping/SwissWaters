using Api.Extensions;
using Core.Helper;
using Core.Interfaces;
using Core.Profiles;
using Core.Repositories;
using Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    logger.Debug("Application Starting Up");

    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCors();

    builder.Services.AddDbContext<SwissWatersContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SwissWatersConnection"));
    });

    builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

    builder.Services.AddScoped<IStationRepository, StationRepository>();
    builder.Services.AddScoped<IStationAbilityRepository, StationAbilityRepository>();
    builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
    builder.Services.AddScoped<IWatersTypeRepository, WatersTypeRepository>();
    builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
    builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ICantonRepository, CantonRepository>();
    builder.Services.AddScoped<ICantonStationRepository, CantonStationRepository>();

    builder.Services.ConfigureAndAddAuthentication();
    builder.Services.ConfigureAndAddSwagger();

    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}