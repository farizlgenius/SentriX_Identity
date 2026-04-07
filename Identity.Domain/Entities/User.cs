using System;
using Identity.Domain.Enums;
using Identity.Domain.Helpers;

namespace Identity.Domain.Entities;

public sealed class User
{
  public string UserId { get; private set; } = string.Empty;
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
  public string RoleName { get; private set; } = string.Empty;
  public int LocationId { get; private set; }
  public string LocationName { get; private set; } = string.Empty;
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }

  public User() { }

  public User(string userid, string username, string password, Title title, string firstName, string middleName, string lastName, Gender gender, string email, string mobile, DateTime createdAt, DateTime updatedAt)
  {
    ValidationHelper.ValidateNotNullOrEmpty(userid, nameof(userid));
    ValidationHelper.ValidateNotNullOrEmpty(username, nameof(username));
    ValidationHelper.ValidateNotNullOrEmpty(password, nameof(password));
    ValidationHelper.ValidateNotNullOrEmpty(firstName, nameof(firstName));
    ValidationHelper.ValidateNotNullOrEmpty(lastName, nameof(lastName));
    ValidationHelper.ValidateNotNullOrEmpty(email, nameof(email));
    this.Mobile = mobile;
    this.UserId = userid;
    Username = username;
    Password = password;
    Title = title;
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    Gender = gender;
    Email = email;
    Mobile = mobile;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public User(string userid, string username, string password, Title title, string firstName, string middleName, string lastName, Gender gender, string email, string mobile, int roleId, string roleName, int locationId, string locationName, DateTime createdAt, DateTime updatedAt)
  {
    ValidationHelper.ValidateNotNullOrEmpty(userid, nameof(userid));
    ValidationHelper.ValidateNotNullOrEmpty(username, nameof(username));
    ValidationHelper.ValidateNotNullOrEmpty(password, nameof(password));
    ValidationHelper.ValidateNotNullOrEmpty(firstName, nameof(firstName));
    ValidationHelper.ValidateNotNullOrEmpty(lastName, nameof(lastName));
    ValidationHelper.ValidateNotNullOrEmpty(email, nameof(email));
    this.Mobile = mobile;
    UserId = userid;
    Username = username;
    Password = password;
    Title = title;
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    Gender = gender;
    Email = email;
    Mobile = mobile;
    RoleId = roleId;
    RoleName = roleName;
    LocationId = locationId;
    LocationName = locationName;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

}


