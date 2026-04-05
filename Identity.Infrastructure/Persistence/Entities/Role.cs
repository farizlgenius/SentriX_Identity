using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Role : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public ICollection<User> users { get; set; } = new List<User>();
  public ICollection<Permission> permissions { get; set; } = new List<Permission>();
  public Role() { }
  public void Update(Identity.Domain.Entities.Role role)
  {
    name = role.Name;
    description = role.Description;
    updated_at = DateTime.UtcNow;
  }
}
