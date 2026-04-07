using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Identity.Api.Helpers;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Identity.Api.Authentication;

public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions { }
public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
{
  private const string HEADER_NAME = "X-API-KEY";
  private readonly IApiKeyService _service;
  public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, IApiKeyService service)
      : base(options, logger, encoder)
  {
    _service = service;
  }
  protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
  {

    var apiKeyHeader = Request.Headers["X-API-KEY"].FirstOrDefault() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(apiKeyHeader))
    {
      Context.Items["AuthError"] = "API Key header (X-API-KEY) is missing";
      return AuthenticateResult.Fail("API Key missing");
    }


    var apiKey = await _service.ValidateApiKeyAsync(apiKeyHeader);
    if (apiKey == null || !apiKey.IsActive)
    {
      Context.Items["AuthError"] = "Invalid API Key";
      return AuthenticateResult.Fail("Invalid API Key");
    }

    if (apiKey.ExpireAt < DateTime.UtcNow)
    {
      Context.Items["AuthError"] = "API Key has expired";
      return AuthenticateResult.Fail("API Key expired");
    }


    // create claims based on DB record 🔥
    var claims = new[]
    {
            new Claim(ClaimTypes.Name, apiKey.Owner),
            new Claim("AuthType", "ApiKey")
        };

    var identity = new ClaimsIdentity(claims, Scheme.Name);
    var principal = new ClaimsPrincipal(identity);
    var ticket = new AuthenticationTicket(principal, Scheme.Name);

    return AuthenticateResult.Success(ticket);

  }

  protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
  {
    var message = "API Key missing or invalid";

    if (Context.Items.TryGetValue("AuthError", out var error))
      message = error?.ToString() ?? message;

    await AuthResponseHelper.Write401(Response, message);
  }

  protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
  {
    await AuthResponseHelper.Write403(Response);
  }
}
