using System;

namespace Identity.Domain.Entities;

public sealed class Token
{
  public string AccessToken { get; init; }
  public string RefreshToken { get; init; }
  public int ExpiresAt { get; init; }
  public DateTime RefreshExpireAt { get; init; }

  public Token(string accessToken, string refreshToken, int expiresAt, DateTime refreshExpireAt)
  {
    AccessToken = accessToken;
    RefreshToken = refreshToken;
    ExpiresAt = expiresAt;
    RefreshExpireAt = refreshExpireAt;

  }

}
