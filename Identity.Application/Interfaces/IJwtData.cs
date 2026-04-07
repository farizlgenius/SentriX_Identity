using System;

namespace Identity.Application.Interfaces;

public interface IJwtData
{
  string Secret { get; }
  string Issuer { get; }
  string Audience { get; }
  short AccessTokenMinutes { get; }
  short RefreshTokenDays { get; }
}
