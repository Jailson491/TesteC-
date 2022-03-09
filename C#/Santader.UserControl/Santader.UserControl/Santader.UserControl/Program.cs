using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Santader.UserControl;
using Santader.UserControl.Data;
using Santader.UserControl.Models;
using Santader.UserControl.Repositories;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System.Text;

try
{


    var builder = WebApplication.CreateBuilder(args);
    var key = Encoding.ASCII.GetBytes(Settings.Secret);

    //builder.Host.UseSerilog(Log.Logger);
    Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Debug()
       .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
       .Enrich.FromLogContext()
       .WriteTo.Console(new RenderedCompactJsonFormatter())
       .WriteTo.File(new RenderedCompactJsonFormatter(), "./logs/log.ndjson")
       .CreateLogger();

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IDeleteRepository, DeleteUserRepository>();

    builder.Services.AddAuthorization(option =>
    {
        option.AddPolicy("admin", policy => policy.RequireRole("manager"));
        option.AddPolicy("employee", policy => policy.RequireRole("employee"));
    });

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddDbContext<AppDbContext>();
    builder.Services.AddDbContext<AppDbContextOra>();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
    new OpenApiSecurityScheme
    { Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
    }
        },
        new string[] {}
    }
        });
    });


    var app = builder.Build();

    app.UseSwagger();
    app.UseAuthentication();
    app.UseAuthorization();

    Log.Information("Iniciando Log");
    app.UseSwaggerUI();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{

    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}