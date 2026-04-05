using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Infrastructure.Persistence.Entities;

public class BaseEntity
{
  [Key]
  public int id { get; set; }
  public DateTime created_at { get; set; }
  public DateTime updated_at { get; set; }

}
