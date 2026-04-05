using System;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Permission
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public bool IsEnabled { get; private set; }
  public bool IsCreated { get; private set; }
  public bool IsUpdated { get; private set; }
  public bool IsDeleted { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }

  public Permission(int id, string name, bool isEnabled, bool isCreated, bool isUpdated, bool isDeleted, DateTime createdAt, DateTime updatedAt)
  {
    ValidationHelper.ValidateNotZero(id, nameof(id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    Id = id;
    Name = name;
    IsEnabled = isEnabled;
    IsCreated = isCreated;
    IsUpdated = isUpdated;
    IsDeleted = isDeleted;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
