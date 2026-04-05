using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Country : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string code { get; set; } = string.Empty;
  public ICollection<Location> locations { get; set; } = new List<Location>();

  public Country() { }

  public void Update(Identity.Domain.Entities.Country country)
  {
    name = country.Name;
    code = country.Description;
    updated_at = DateTime.UtcNow;
  }

}
