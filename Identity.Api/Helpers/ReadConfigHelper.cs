using System;
using Identity.Application.Settings;

namespace Identity.Api.Helpers;

public class ReadConfigHelper
{
  public static void ReadConfig(WebApplicationBuilder builder)
  {
    // ==========================
    // Read config from appsetting.json
    // ==========================

    builder.Services
              .AddOptions<Jwt>()
              .Bind(builder.Configuration.GetSection("JwtSetting"))
              .ValidateOnStart();

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
