using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Company : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string address { get; set; } = string.Empty;

  public string postal_code { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;

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

  public void Update(Identity.Domain.Entities.Company company)
  {
    name = company.Name;
    address = company.Address;
    postal_code = company.PostalCode;
    description = company.Description;
    updated_at = DateTime.UtcNow;
  }

}
