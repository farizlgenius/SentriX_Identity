using System;

namespace Identity.Domain.Constants;

public sealed class AuthResponseMessage
{
  public const string LoginSuccess = "Login successful.";
  public const string LogoutSuccess = "Logout successful.";
  public const string InvalidCredentials = "Invalid username or password.";
  public const string UserNotFound = "User not found.";
  public const string UsernameCannotBeEmpty = "Username cannot be empty.";
  public const string PasswordCannotBeEmpty = "Password cannot be empty.";
  public const string RefreshTokenNotFound = "Refresh token not found.";
  public const string RefreshExpired = "Refresh token expired.";
  public const string RefreshTokenInvalid = "Refresh token invalid.";
  public const string GetMeSuccess = "Get Me Successful.";
  public const string RefreshTokenSuccess = "Refresh token successful.";
}
