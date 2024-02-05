using CMS.API.Authorization;
using CMS.API.Contracts;
using CMS.API.Helpers;
using CMS.API.Mapper;
using CMS.API.Repositories;
using CMS.API.Services;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Serilog;
using Microsoft.EntityFrameworkCore;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/Log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();

    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<DataContext>();
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MMC APIs", Version = "v1" });

        c.OperationFilter<FileUploadParams>();
    });

    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.AddDbContext<DataContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("CMSDB")));
    services.AddAutoMapper(typeof(MappingProfile));

    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IAccountService, AccountService>();
    services.AddScoped<IEmailService, EmailService>();
    services.AddScoped<IApplicationSettingsRepository, ApplicationSettingsRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IEventRepository, EventRepository>();
    services.AddScoped<IPartnerRepository, PartnerRepository>();
    services.AddScoped<ISpeakerRepository, SpeakerRepository>();
    services.AddScoped<ISponsorRepository, SponsorRepository>();
    services.AddScoped<IPayementRepository, PayementRepository>();
    services.AddScoped<IPlannerRepository, PlannerRepository>();
    services.AddScoped<IPlannerSpeakerRepository, PlannerSpeakerRepository>();
    services.AddScoped<IEventAttendanceRepository, EventAttendanceRepository>();
    services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
    services.AddScoped<IPartnerEventRepository, PartnerEventRepository>();
    services.AddScoped<ISponsorEventRepository, SponsorEventRepository>();


    var app = builder.Build();

    app.UseStaticFiles();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMC APIs");
    });

    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseMiddleware<JwtMiddleware>();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}


