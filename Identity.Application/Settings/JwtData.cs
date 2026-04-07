using System;
using Identity.Application.Interfaces;

namespace Identity.Application.Settings;

public sealed class JwtData : IJwtData
{
  public string Secret { get; set; } = string.Empty;

  public string Issuer { get; set; } = string.Empty;

  public string Audience { get; set; } = string.Empty;

  public short AccessTokenMinutes { get; set; }
  public short RefreshTokenDays { get; set; }
}
