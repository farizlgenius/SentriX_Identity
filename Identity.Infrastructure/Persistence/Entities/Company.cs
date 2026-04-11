using System;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Company : BaseEntity
{
  public string name { get; set; } = string.Empty;
  public string address { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
  public ICollection<Operator> operators { get; set; } = new List<Operator>();

  /// <summary>
  /// Releationship.
  /// </summary>

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
  }


  public void Update(Identity.Domain.Entities.Company company)
  {
    name = company.Name;
    address = company.Address;
    description = company.Description;
    updated_at = DateTime.UtcNow;
  }

}
