using System;

namespace Identity.Domain.Entities;

public sealed class Role
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public List<Permission> Permissions { get; private set; } = new List<Permission>();
  public int LocationId { get; private set; }

  public Role(int id, string name, List<Permission> permissions, int locationId)
  {
    Id = id;
    Name = name;
    Permissions = permissions;
    LocationId = locationId;
  }

}
