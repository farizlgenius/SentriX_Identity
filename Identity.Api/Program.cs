
using System.Text;
using Identity.Api.Helpers;
using Identity.Api.Settings;
using Identity.Application.Settings;
using Identity.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================
        // Read config from appsetting.json
        // ==========================
        ReadConfigHelper.ReadConfig(builder);

        // ==========================
        // Cache service setting
        // ==========================
        // builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
        // {
        //     var configuration = builder.Configuration.GetSection("Redis")["ConnectionString"] ?? "localhost:6379";
        //     return ConnectionMultiplexer.Connect(configuration);
        // });

        // ==========================
        // RabbitMQ DI service setting
        // ==========================
        // builder.Services.AddSingleton<IRabbitMqPersistentConnection, RabbitMqPersistentConnection>();
        // builder.Services.AddScoped<IMessagePublisher, RabbitMqPublisher>();

        // ==========================
        // Setting Routing option
        // ==========================
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true; // optional
        });

        // ==========================
        // Database connection
        // ==========================
        DatabaseConnectionSettingHelper.DatabaseConnectionHelper(builder);

        // ==========================
        // Jwt Setting
        // ==========================
        AuthenticationSettingHelper.AuthenticationSetting(builder);


        // ==========================
        // Adding App Dependency Injection
        // ==========================
        DISettingHelper.DISetting(builder);

        // ==========================
        // Add Authorization
        // ==========================
        builder.Services.AddAuthorization();

        // ==========================
        // Swagger Setting
        // ==========================
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        SwaggerSettingHelper.SwaggerSetting(builder);


        // ==========================
        // Add Controllers
        // ==========================
        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
