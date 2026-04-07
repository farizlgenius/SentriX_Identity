using System;
using Identity.Domain.Enums;

namespace Identity.Domain.Entities;

public sealed class RefreshToken
{
  public string HashedToken { get; set; } = string.Empty;
  public string UserId { get; set; } = string.Empty;
  public string UserName { get; set; } = string.Empty;
  public TokenAction Action { get; set; }
  public DateTime ExpiredAt { get; set; }

  public RefreshToken(string hash, string userid, string username, TokenAction action, DateTime expire)
  {
    this.HashedToken = hash;
    this.UserId = userid;
    this.UserName = username;
    this.Action = action;
    this.ExpiredAt = expire;
  }

}
