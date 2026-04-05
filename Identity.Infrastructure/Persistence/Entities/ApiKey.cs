using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class ApiKey : BaseEntity
{
  public string key { get; set; } = string.Empty;
  public string owner { get; set; } = string.Empty;
  public bool is_active { get; set; }
  public DateTime ExpireAt { get; set; }

  public ApiKey() { }

}
