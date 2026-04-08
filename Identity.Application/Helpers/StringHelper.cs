using System;
using System.Globalization;

namespace Identity.Application.Helpers;

public sealed class StringHelper
{
  public static string ToCapital(string msg)
  {
    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
    string result = ti.ToTitleCase(msg);
    return result;
  }
}
