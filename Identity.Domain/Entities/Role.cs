using System;

namespace Identity.Domain.Entities;

public sealed class Role
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }

  public Role(int id, string name, string description, DateTime createdAt, DateTime updatedAt)
  {
    Id = id;
    Name = name;
    Description = description;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

}
