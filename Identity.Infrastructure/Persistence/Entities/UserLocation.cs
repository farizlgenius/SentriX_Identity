using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class UserLocation
{
  public int user_id { get; set; }
  public User user { get; set; } = default!;
  public int location_id { get; set; }
  public Location location { get; set; } = default!;
}
