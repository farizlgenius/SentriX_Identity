using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Role : BaseEntity
{
  public string name { get; set; } = string.Empty;

  // Relation here
  public int location_id { get; set; }
  public Location location { get; set; } = default!;
  public ICollection<Operator> users { get; set; } = new List<Operator>();
  public ICollection<Permission> permissions { get; set; } = new List<Permission>();
  public Role() { }
  public Role(Domain.Entities.Role domain)
  {
    name = domain.Name;
    location_id = domain.LocationId;
    permissions = domain.Permissions.Select(p => new Persistence.Entities.Permission(p)).ToList();
    created_at = DateTime.UtcNow;
    updated_at = DateTime.UtcNow;
  }
  public void AddPermissions(List<Identity.Domain.Entities.Permission> permissions)
  {
    this.permissions = permissions.Select(p => new Persistence.Entities.Permission(this.id, p)).ToList(); ;
  }
  public void Update(Identity.Domain.Entities.Role role)
  {
    name = role.Name;
    location_id = role.LocationId;
    permissions = role.Permissions.Select(p => new Persistence.Entities.Permission(role.Id, p)).ToList();
    updated_at = DateTime.UtcNow;
  }
}
