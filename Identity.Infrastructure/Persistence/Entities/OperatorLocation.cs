using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class OperatorLocation
{
  public int operator_id { get; set; }
  public Operator @operator { get; set; } = default!;
  public int location_id { get; set; }
  public Location location { get; set; } = default!;

  public OperatorLocation() { }

  public OperatorLocation(int user, int location)
  {
    operator_id = user;
    location_id = location;

  }
}
