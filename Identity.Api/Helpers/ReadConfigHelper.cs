using System;
using Identity.Application.Interfaces;
using Identity.Application.Settings;

namespace Identity.Api.Helpers;

public class ReadConfigHelper
{
  public static void ReadConfig(WebApplicationBuilder builder)
  {
    // ==========================
    // Read config from appsetting.json
    // ==========================
    builder.Services.Configure<RedisSettings>(
      builder.Configuration.GetSection("Redis")
    );

    builder.Services
           .AddOptions<JwtData>()
           .Bind(builder.Configuration.GetSection("JwtSetting"))
           .ValidateOnStart();

    builder.Services.AddSingleton<IJwtData>(sp => sp.GetRequiredService<
        Microsoft.Extensions.Options.IOptions<JwtData>>().Value);

    // builder.Services
    //        .AddOptions<HttpSetting>()
    //        .Bind(builder.Configuration.GetSection("HttpSetting"))
    //        .ValidateOnStart();

    // builder.Services
    //        .AddOptions<RabbitMqSetting>()
    //        .Bind(builder.Configuration.GetSection("RabbitMq"))
    //        .ValidateOnStart();
  }

}
