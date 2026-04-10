using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Location : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public int country_id { get; set; }
  public Country country { get; set; } = default!;
  public ICollection<Company> companies { get; set; } = new List<Company>();
  public ICollection<UserLocation> user_locations { get; set; } = new List<UserLocation>();
  public ICollection<Role> roles { get; set; } = new List<Role>();
  public Location() { }
  public Location(Domain.Entities.Location d)
  {
    name = d.Name;
    description = d.Description;
    country_id = d.CountryId;
    created_at = DateTime.UtcNow;
    updated_at = DateTime.UtcNow;
  }
  public void Update(Identity.Domain.Entities.Location location)
  {
    name = location.Name;
    description = location.Description;
    country_id = location.CountryId;
    updated_at = DateTime.UtcNow;
  }
}
