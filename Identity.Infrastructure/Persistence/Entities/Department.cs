using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Department : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public int company_id { get; set; }
  public Company company { get; set; } = null!;
  public ICollection<User> users { get; set; } = new List<User>();

  /// <summary>
  /// Relation
  /// </summary>
  public Department() { }
  public void Update(Identity.Domain.Entities.Department department)
  {
    name = department.Name;
    description = department.Description;
    updated_at = DateTime.UtcNow;
  }

}
