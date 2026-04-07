

using Microsoft.OpenApi.Models;

namespace Identity.Api.Helpers;

public class SwaggerSettingHelper
{
  public static void SwaggerSetting(WebApplicationBuilder builder)
  {
    // Add services to the container.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
{
  // ===== DOC =====
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

  // ===== JWT SCHEME =====
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Enter: Bearer {token}"
  });

  // ===== API KEY SCHEME =====
  c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
  {
    Name = "X-API-KEY",
    Type = SecuritySchemeType.ApiKey,
    In = ParameterLocation.Header
  });

  // ⭐⭐⭐ THE IMPORTANT PART ⭐⭐⭐
  c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
    },
    {
        new OpenApiSecurityScheme
        {
          Reference = new OpenApiReference
          {
            Type = ReferenceType.SecurityScheme,
            Id="ApiKey"
          }
        },
        new string[] {}
    }
            });


});



  }

}
