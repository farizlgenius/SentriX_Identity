using System;

namespace Identity.Domain.Constants;

public sealed class LocationResponseMessage
{
  public static string NameEmpty = "Name must not empty.";
  public static string DuplicatedName = "Found duplicate name.";
  public static string CountryInvalid = "Country invalid.";
}
