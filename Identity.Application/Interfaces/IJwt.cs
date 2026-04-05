using System;

namespace Identity.Application.Interfaces;

public interface IJwt
{
  string Secret { get; }
  string Issuer { get; }
  string Audience { get; }
  short AccessTokenMinutes { get; }
}
