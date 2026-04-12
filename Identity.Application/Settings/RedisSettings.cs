using System;

namespace Identity.Application.Settings;

public sealed class RedisSettings
{
  public string? ConnectionString { get; set; }
  public bool Enabled { get; set; }

}
