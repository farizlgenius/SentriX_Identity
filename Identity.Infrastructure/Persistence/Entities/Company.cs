using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Company : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string address { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public ICollection<User> users { get; set; } = new List<User>();

  /// <summary>
  /// Releationship.
  /// </summary>
  public int location_id { get; set; }
  public Location location { get; set; } = null!;
  public ICollection<Department> departments { get; set; } = new List<Department>();

  /// <summary>
  /// Constructor for EF Core. Not intended for direct use. Use the Update method to set properties instead.
  /// </summary>

  public Company() { }
  public Company(Domain.Entities.Company domain)
  {
    name = domain.Name;
    address = domain.Address;
    description = domain.Description;
    location_id = domain.LocationId;
  }

  public void Update(Identity.Domain.Entities.Company company)
  {
    name = company.Name;
    address = company.Address;
    description = company.Description;
    location_id = company.LocationId;
    updated_at = DateTime.UtcNow;
  }

}
