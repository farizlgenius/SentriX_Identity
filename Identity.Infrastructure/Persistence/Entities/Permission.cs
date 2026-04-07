using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Permission : BaseEntity
{
  public int role_id { get; set; }
  public Role role { get; set; } = null!;
  public int feature_id { get; set; }
  public Feature feature { get; set; } = null!;
  public bool is_enabled { get; set; }
  public bool is_created { get; set; }
  public bool is_updated { get; set; }
  public bool is_deleted { get; set; }

  public Permission() { }
  public void Update(Identity.Domain.Entities.Permission permission)
  {
    role_id = permission.Id;
    feature_id = permission.Id;
    is_enabled = permission.IsEnabled;
    is_created = permission.IsCreated;
    is_updated = permission.IsUpdated;
    is_deleted = permission.IsDeleted;
    updated_at = DateTime.UtcNow;
  }
}
