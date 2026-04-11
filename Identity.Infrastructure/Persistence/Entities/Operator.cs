using System;
using Identity.Domain.Enums;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class Operator : BaseEntity
{
  public string operator_id { get; set; } = string.Empty;
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
  public Role role { get; set; } = null!;
  public int role_id { get; set; }
  public ICollection<OperatorLocation> operator_locations { get; set; } = new List<OperatorLocation>();

  public Operator() { }
  public Operator(Domain.Entities.Operator domain)
  {
    operator_id = domain.OperatorId;
    username = domain.Username;
    title = domain.Title;
    firstname = domain.FirstName;
    middlename = domain.MiddleName;
    lastname = domain.LastName;
    gender = domain.Gender;
    email = domain.Email;
    mobile = domain.Mobile;
    role_id = domain.RoleId;
    created_at = DateTime.UtcNow;
    updated_at = DateTime.UtcNow;
  }

  public void AddPassword(string password)
  {
    this.password = password;
  }

  public void AddLocation(int userid, List<int> locations)
  {
    operator_locations = locations.Select(ul => new OperatorLocation(userid, ul)).ToList();
  }

  public void UpdatePassword(string hashed)
  {
    this.password = hashed;
  }

  public void Update(Identity.Domain.Entities.Operator user)
  {
    operator_id = user.OperatorId;
    username = user.Username;
    title = user.Title;
    firstname = user.FirstName;
    middlename = user.MiddleName;
    lastname = user.LastName;
    gender = user.Gender;
    email = user.Email;
    mobile = user.Mobile;
    role_id = user.RoleId;
    updated_at = DateTime.UtcNow;
  }
}
