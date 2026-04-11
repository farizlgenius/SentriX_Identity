using System;
using Identity.Domain.Enums;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class Operator
{
  public int Id { get; private set; }
  public string OperatorId { get; private set; } = string.Empty;
  public string Username { get; private set; } = string.Empty;
  public string Password { get; private set; } = string.Empty;
  public Title Title { get; private set; } = Title.Other;
  public string FirstName { get; private set; } = string.Empty;
  public string MiddleName { get; private set; } = string.Empty;
  public string LastName { get; private set; } = string.Empty;
  public Gender Gender { get; private set; } = Gender.Male;
  public string Email { get; private set; } = string.Empty;
  public string Mobile { get; private set; } = string.Empty;
  public int RoleId { get; private set; }
  public List<int> LocationId { get; private set; } = new List<int>();

  public Operator() { }

  public Operator(string operatorid, string username, string password, Title title, string firstName, string middleName, string lastName, Gender gender, string email, string mobile, List<int> locationId, int roleId)
  {
    ValidationHelper.ValidateNotNullOrEmpty(operatorid, nameof(operatorid));
    ValidationHelper.ValidateNotNullOrEmpty(username, nameof(username));
    ValidationHelper.ValidateNotNullOrEmpty(password, nameof(password));
    ValidationHelper.ValidateNotNullOrEmpty(firstName, nameof(firstName));
    ValidationHelper.ValidateNotNullOrEmpty(lastName, nameof(lastName));
    ValidationHelper.ValidateNotNullOrEmpty(email, nameof(email));
    this.Mobile = mobile;
    this.OperatorId = operatorid;
    Username = username;
    Password = password;
    Title = title;
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    Gender = gender;
    Email = email;
    Mobile = mobile;
    LocationId = locationId;
    RoleId = roleId;
  }

  public Operator(int id, string userid, string username, Title title, string firstName, string middleName, string lastName, Gender gender, string email, string mobile, List<int> locationId, int roleId)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(Id));
    ValidationHelper.ValidateNotNullOrEmpty(userid, nameof(userid));
    ValidationHelper.ValidateNotNullOrEmpty(username, nameof(username));
    ValidationHelper.ValidateNotNullOrEmpty(firstName, nameof(firstName));
    ValidationHelper.ValidateNotNullOrEmpty(lastName, nameof(lastName));
    ValidationHelper.ValidateNotNullOrEmpty(email, nameof(email));
    Id = id;
    this.Mobile = mobile;
    this.OperatorId = userid;
    Username = username;
    Title = title;
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    Gender = gender;
    Email = email;
    Mobile = mobile;
    LocationId = locationId;
    RoleId = roleId;
  }

}


