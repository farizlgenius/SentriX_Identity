using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Department : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public int company_id { get; set; }
  public Company company { get; set; } = null!;
  public ICollection<Position> positions { get; set; } = new List<Position>();
  public ICollection<Operator> operators { get; set; } = new List<Operator>();

  /// <summary>
  /// Relation
  /// </summary>
  public Department() { }

  public Department(Domain.Entities.Department domain)
  {
    name = domain.Name;
    description = domain.Description;
    company_id = domain.CompanyId;
    created_at = DateTime.UtcNow;
    updated_at = DateTime.UtcNow;
  }
  public void Update(Identity.Domain.Entities.Department domain)
  {
    name = domain.Name;
    description = domain.Description;
    company_id = domain.CompanyId;
    updated_at = DateTime.UtcNow;
  }

}
