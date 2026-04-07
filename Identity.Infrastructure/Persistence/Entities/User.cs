using System;
using Identity.Domain.Enums;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class User : BaseEntity
{
  public string user_id { get; set; } = string.Empty;
  public string username { get; set; } = string.Empty;
  public string password { get; set; } = string.Empty;
  public Title title { get; set; } = Title.Mr;
  public string firstname { get; set; } = string.Empty;
  public string middlename { get; set; } = string.Empty;
  public string lastname { get; set; } = string.Empty;
  public Gender gender { get; set; } = Gender.Male;
  public string email { get; set; } = string.Empty;
  public string mobile { get; set; } = string.Empty;

  /// <summary>
  /// Relation
  /// </summary>
  public Company? company { get; set; } = null!;
  public int? company_id { get; set; }
  public Position? position { get; set; } = null!;
  public int? position_id { get; set; }
  public Department? department { get; set; } = null!;
  public int? department_id { get; set; }
  public Role role { get; set; } = null!;
  public int role_id { get; set; }
  public ICollection<UserLocation> user_locations { get; set; } = new List<UserLocation>();

  public User() { }

  public void Update(Identity.Domain.Entities.User user)
  {
    user_id = user.UserId;
    username = user.Username;
    title = user.Title;
    firstname = user.FirstName;
    middlename = user.MiddleName;
    lastname = user.LastName;
    gender = user.Gender;
    email = user.Email;
    mobile = user.Mobile;
    updated_at = DateTime.UtcNow;
  }
}
