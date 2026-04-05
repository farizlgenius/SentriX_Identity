using System;

namespace Identity.Domain.Helpers;

public sealed class ValidationHelper
{
  public static void ValidateNotNullOrEmpty(string value, string parameterName)
  {
    if (string.IsNullOrEmpty(value))
    {
      throw new ArgumentException($"'{parameterName}' cannot be null or empty.", parameterName);
    }
  }

  public static void ValidateNotZero(int value, string parameterName)
  {
    if (value <= 0)
    {
      throw new ArgumentException($"'{parameterName}' cannot be zero.", parameterName);
    }
  }

}
