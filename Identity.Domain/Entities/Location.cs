using System;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Location
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public int CountryId { get; set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }

  public Location(int id, string name, int countryId, string description, DateTime createdAt, DateTime updatedAt)
  {
    ValidationHelper.ValidateNotZero(id, nameof(id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    Id = id;
    Name = name;
    CountryId = countryId;
    Description = description;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
