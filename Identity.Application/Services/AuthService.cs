using System;
using Identity.Application.DTOs;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Identity.Application.Services;

public class AuthService(IAuthRepository repo, IJwtService service) : IAuthService
{
  public async Task<BaseDto> GetMeByUsernameAndRoleIdAsync(string username, int roleId)
  {
    var locations = await repo.GetLocationsByUsernameAsync(username);
    var permissions = await repo.GetPermissionsByRoleIdAsync(roleId);
    return new MeDto(System.Net.HttpStatusCode.OK, AuthResponseMessage.GetMeSuccess, DateTime.UtcNow, locations, permissions);
  }

  public async Task<BaseDto> LoginAsync(LoginDto loginDto, HttpResponse response)
  {
    //Check username is empty
    if (string.IsNullOrEmpty(loginDto.Username))
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.UsernameCannotBeEmpty, DateTime.UtcNow);

    //Check password is empty
    if (string.IsNullOrEmpty(loginDto.Password))
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.PasswordCannotBeEmpty, DateTime.UtcNow);

    // Check username existence
    var userExists = await repo.IsAnyUserExistsAsync(loginDto.Username);
    if (!userExists)
      return new BaseDto(System.Net.HttpStatusCode.NotFound, AuthResponseMessage.UserNotFound, DateTime.UtcNow);

    // Validate Password
    var pass = await repo.GetUserHashPasswordAsync(loginDto.Username);
    var isValidPassword = PasswordHasher.VerifyPassword(loginDto.Password, pass);
    if (!isValidPassword)
      return new BaseDto(System.Net.HttpStatusCode.Unauthorized, AuthResponseMessage.InvalidCredentials, DateTime.UtcNow);

    // Get User
    var user = await repo.GetUserByUsernameAsync(loginDto.Username);

    // Generate token (for demonstration, using a simple string)
    var token = await service.GenerateTokenAsync(user);

    response.Cookies.Append("refresh_token", token.RefreshToken, new CookieOptions
    {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.Strict,
      Path = "/api/Auth",
      Expires = new DateTimeOffset(token.RefreshExpireAt, TimeSpan.Zero)
    });

    return new TokenDto(
      System.Net.HttpStatusCode.OK,
      AuthResponseMessage.LoginSuccess,
      DateTime.UtcNow,
      token.AccessToken,
      token.RefreshToken,
      token.ExpiresAt
      );

  }

  public async Task<BaseDto> LogoutAsync(string refreshToken, HttpResponse response)
  {
    var hashed = TokenHasher.Hash(refreshToken);
    var refresh = await service.GetRefreshTokenAsync(hashed);

    // Validate token
    if (string.IsNullOrWhiteSpace(refresh.HashedToken))
      return new BaseDto(System.Net.HttpStatusCode.NotFound, AuthResponseMessage.RefreshTokenNotFound, DateTime.UtcNow);

    if (refresh.ExpiredAt < DateTime.UtcNow)
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.RefreshExpired, DateTime.UtcNow);

    if (refresh.Action.Equals(TokenAction.REVOKE))
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.RefreshTokenInvalid, DateTime.UtcNow);

    await service.RevokeTokenAsync(refreshToken);

    response.Cookies.Delete("refresh_token", new CookieOptions
    {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.Strict,
      Path = "/api/Auth"
    });

    return new BaseDto(System.Net.HttpStatusCode.OK, AuthResponseMessage.LogoutSuccess, DateTime.UtcNow);
  }

  public async Task<BaseDto> RefreshTokenAsync(string refreshToken, HttpResponse response)
  {
    var inCommingHashed = TokenHasher.Hash(refreshToken);
    var refresh = await service.GetRefreshTokenAsync(inCommingHashed);
    // Validate token
    if (string.IsNullOrWhiteSpace(refresh.HashedToken))
      return new BaseDto(System.Net.HttpStatusCode.NotFound, AuthResponseMessage.RefreshTokenNotFound, DateTime.UtcNow);

    if (refresh.ExpiredAt < DateTime.UtcNow)
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.RefreshExpired, DateTime.UtcNow);

    if (refresh.Action.Equals(TokenAction.REVOKE))
      return new BaseDto(System.Net.HttpStatusCode.BadRequest, AuthResponseMessage.RefreshTokenInvalid, DateTime.UtcNow);

    // Generate token (for demonstration, using a simple string)
    var token = await service.RefreshTokenAsync(refresh);

    response.Cookies.Append("refresh_token", token.RefreshToken, new CookieOptions
    {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.Strict,
      Path = "/api/Auth",
      Expires = new DateTimeOffset(token.RefreshExpireAt, TimeSpan.Zero)
    });

    return new TokenDto(
      System.Net.HttpStatusCode.OK,
      AuthResponseMessage.RefreshTokenSuccess,
      DateTime.UtcNow,
      token.AccessToken,
      token.RefreshToken,
      token.ExpiresAt
      );


  }
}
