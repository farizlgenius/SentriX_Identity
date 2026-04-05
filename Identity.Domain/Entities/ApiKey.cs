using System;

namespace Identity.Domain.Entities;

public class ApiKey
{
  public string Key { get; set; } = string.Empty;
  public string Owner { get; set; } = string.Empty;
  public bool IsActive { get; set; }
  public DateTime ExpireAt { get; set; }

  public ApiKey(string key, string owner, bool isActive, DateTime expireAt)
  {
    Key = key;
    Owner = owner;
    IsActive = isActive;
    ExpireAt = expireAt;
  }

}
