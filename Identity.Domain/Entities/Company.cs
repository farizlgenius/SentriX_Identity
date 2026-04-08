using System;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Company
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Address { get; private set; } = string.Empty;
  public string PostalCode { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }
  public Company(
    int id,
    string name,
    string address,
    string postalCode,
    string description,
    DateTime createdAt,
    DateTime updatedAt)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(name));
    Id = id;
    Name = name;
    Address = address;
    PostalCode = postalCode;
    Description = description;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

}
