using System;

namespace Identity.Domain.Constants;

public class ResponseMessage
{

  public static string UserIdEmpty = "OperatorId must not be empty.";
  public static string UsernameEmpty = "Username must not be empty.";
  public static string PasswordEmpty = "Password must not be empty.";
  public static string NameEmpty = "Name must not empty.";
  public static string FirstnameEmpty = "Firstname must not empty.";
  public static string LastnameEmpty = "Lastname must not empty.";
  public static string EmailEmpty = "Email must not empty.";
  public static string DuplicatedName = "Found duplicate name.";
  public static string DuplicatedUsername = "Found duplicate username.";
  public static string DuplicatedUserId = "Found duplicate operatorid.";
  public static string CountryInvalid = "Country invalid.";
  public static string LocationNotFound = "Location not found.";
  public static string LocationInvalid = "Location invalid.";
  public static string RecordNotFound = "Record not found.";
  public static string QueryIdInvalid = "Query id invalid.";
  public static string CompanyInvalid = "Company invalid.";
  public static string CompanyNotFound = "Company not found.";
  public static string PositionInvalid = "Position invalid.";
  public static string DepartmentInvalid = "Department invalid.";
  public static string RoleInvalid = "Role invalid.";

}
