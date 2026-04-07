using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Position : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public int? department_id { get; set; }
  public Department? department { get; set; }
  public ICollection<User> users { get; set; } = new List<User>();
  public Position() { }
  public void Update(Identity.Domain.Entities.Position position)
  {
    name = position.Name;
    description = position.Description;
    updated_at = DateTime.UtcNow;
  }


}
