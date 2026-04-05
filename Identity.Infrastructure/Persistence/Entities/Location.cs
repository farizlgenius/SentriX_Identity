using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Location : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public string city { get; set; } = string.Empty;
  public int country_id { get; set; }
  public Country country { get; set; } = new Country();
  public ICollection<Company> companies { get; set; } = new List<Company>();
  public Location() { }
  public void Update(Identity.Domain.Entities.Location location)
  {
    name = location.Name;
    description = location.Description;
    city = location.City;
    country_id = location.CountryId;
    updated_at = DateTime.UtcNow;
  }
}
