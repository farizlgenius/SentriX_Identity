using System;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Department
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public int CompanyId { get; private set; }

  public Department(int id, string name, string description, int companyId)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    Id = id;
    Name = name;
    Description = description;
    CompanyId = companyId;
  }
}
