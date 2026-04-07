using System;

namespace Identity.Domain.Entities;

public class BaseDomain
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
