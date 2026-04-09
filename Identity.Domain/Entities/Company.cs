using System;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Company
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Address { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public int LocationId { get; private set; }
  public Company(
    int id,
    string name,
    string address,
    string description,
    int locationId)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    ValidationHelper.ValidateNotMinus(locationId, nameof(LocationId));
    Id = id;
    Name = name;
    Address = address;
    Description = description;
    LocationId = locationId;

  }
}
