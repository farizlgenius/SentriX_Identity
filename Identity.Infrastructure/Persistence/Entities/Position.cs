using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Position : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public int department_id { get; set; }
  public Department department { get; set; } = default!;
  public ICollection<Operator> operators { get; set; } = new List<Operator>();
  public Position() { }

  public Position(string name, string description, int department_id)
  {
    this.name = name;
    this.description = description;
    this.department_id = department_id;
  }
  public void Update(Identity.Domain.Entities.Position position)
  {
    name = position.Name;
    description = position.Description;
    department_id = position.DepartmentId;
    updated_at = DateTime.UtcNow;
  }


}
