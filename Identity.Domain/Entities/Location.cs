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

  public Location(int id, string name, int countryId, string description)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(Id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    Id = id;
    Name = name;
    ValidationHelper.ValidateNotMinus(countryId, nameof(CountryId));
    CountryId = countryId;
    Description = description;
  }
}
