using System;

namespace Identity.Domain.Constants;

public class ResponseMessage
{

  public static string NameEmpty = "Name must not empty.";
  public static string DuplicatedName = "Found duplicate name.";
  public static string CountryInvalid = "Country invalid.";
  public static string LocationNotFound = "Location not found.";
  public const string LocationInvalid = "Location invalid.";
  public const string RecordNotFound = "Record not found.";

}
