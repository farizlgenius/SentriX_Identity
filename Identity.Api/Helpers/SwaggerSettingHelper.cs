using System;
using Microsoft.OpenApi;

namespace Identity.Api.Helpers;

public class SwaggerSettingHelper
{
  public static void SwaggerSetting(WebApplicationBuilder builder)
  {
    // Add services to the container.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new()
      {
        Title = "SentriX Identity API",
        Version = "v1",
        Description = "API for Identity Management in SentriX System",
        Contact = new()
        {
          Name = "SentriX Team",
          Email = "support@sentrix.com",
          Url = new Uri("https://sentrix.com")
        }
      });

      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer prefix. Example: Bearer {token}",
        Name = "Authorization",
        Scheme = "Bearer"
      });

      c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
      {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Description = "API Key needed to access endpoints",
        Scheme = "ApiKey"
      });

      // 🔐 REQUIRE JWT (Swashbuckle 10 way)
      c.AddSecurityRequirement(document =>
          new OpenApiSecurityRequirement
          {
            [
                  new OpenApiSecuritySchemeReference("Bearer")
              ] = new List<string>(),
            [
                  new OpenApiSecuritySchemeReference("ApiKey")
              ] = new List<string>()
          });
    });


  }

}
