using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Feature : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public ICollection<Permission> permissions { get; set; } = new List<Permission>();
  public Feature() { }
  public void Update(Identity.Domain.Entities.Feature feature)
  {
    name = feature.Name;
    updated_at = DateTime.UtcNow;
  }

}
