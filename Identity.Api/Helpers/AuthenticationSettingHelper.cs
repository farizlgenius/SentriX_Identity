using System;
using System.Text;
using Identity.Api.Authentication;
using Identity.Application.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Helpers;

public class AuthenticationSettingHelper
{
  public static void AuthenticationSetting(WebApplicationBuilder builder)
  {

    var jwtCfg = builder.Configuration.GetSection("JwtSetting");
    var jwtSecret = jwtCfg["Secret"] ?? "THIS_IS_DEFAULT_SECRET";
    var issuer = jwtCfg["Issuer"];
    var audience = jwtCfg["Audience"];
    var accessTokenMinute = int.Parse(jwtCfg["AccessTokenMinutes"] ?? "60");

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

    // Add Authentication
    builder.Services.AddAuthentication(
      options =>
    {
      options.DefaultScheme = "SmartScheme";
      // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

      // options.DefaultAuthenticateScheme = "SmartScheme";
      // options.DefaultChallengeScheme = "SmartScheme";
    }
    )
    .AddPolicyScheme("SmartScheme", "JWT or API Key", options =>
{
  options.ForwardDefaultSelector = context =>
  {
    var hasApiKey = context.Request.Headers.ContainsKey("X-API-KEY");
    var hasBearer = context.Request.Headers.ContainsKey("Authorization");
    Console.WriteLine($"🔍 Authentication Header Check - HasApiKey: {hasApiKey}, HasBearer: {hasBearer}");

    if (hasApiKey)
      return "ApiKey";

    if (hasBearer)
      return JwtBearerDefaults.AuthenticationScheme;

    // default if nothing provided
    return JwtBearerDefaults.AuthenticationScheme;
  };
}).AddJwtBearer("Bearer", options =>
    {
      //options.RequireHttpsMetadata = true; // set false only for local dev
      //options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = issuer,

        ValidateAudience = true,
        ValidAudience = audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
      };

      options.Events = new JwtBearerEvents
      {
        OnChallenge = async context =>
    {
      context.HandleResponse(); // stop default 401 page

      var message = "Jwt Token invalid or missing";

      if (context.AuthenticateFailure != null)
        message = context.AuthenticateFailure.Message;

      await AuthResponseHelper.Write401(context.Response, message);
    },

        OnForbidden = async context =>
        {
          await AuthResponseHelper.Write403(context.Response);
        },

        OnAuthenticationFailed = context =>
        {
          Console.WriteLine("❌ JWT FAILED: " + context.Exception.Message);
          return Task.CompletedTask;
        },

        OnTokenValidated = context =>
        {
          Console.WriteLine("✅ TOKEN VALIDATED");
          return Task.CompletedTask;
        }


      };
    })
    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(
        "ApiKey", options => { });
  }
}
