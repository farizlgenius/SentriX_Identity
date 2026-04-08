using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Identity.Application.Services;

public class AuthService(IAuthRepository repo, IJwtService service) : IAuthService
{
  public async Task<MeDto> GetMeByUsernameAndRoleIdAsync(string username, int roleId)
  {
    var locations = await repo.GetLocationsByUsernameAsync(username);
    var permissions = await repo.GetPermissionsByRoleIdAsync(roleId);
    return new MeDto(System.Net.HttpStatusCode.OK, AuthResponseMessage.GetMeSuccess, DateTime.UtcNow, locations, permissions);
  }

  public async Task<TokenDto> LoginAsync(LoginDto loginDto, HttpResponse response)
  {
    //Check username is empty
    if (string.IsNullOrEmpty(loginDto.Username))
      throw new BadRequestException(AuthResponseMessage.UsernameCannotBeEmpty);

    //Check password is empty
    if (string.IsNullOrEmpty(loginDto.Password))
      throw new BadRequestException(AuthResponseMessage.PasswordCannotBeEmpty);

    // Check username existence
    var userExists = await repo.IsAnyUserExistsAsync(loginDto.Username);
    if (!userExists)
      throw new BadRequestException(AuthResponseMessage.UserNotFound);

    // Validate Password
    var pass = await repo.GetUserHashPasswordAsync(loginDto.Username);
    var isValidPassword = PasswordHasher.VerifyPassword(loginDto.Password, pass);
    if (!isValidPassword)
      throw new BadRequestException(AuthResponseMessage.InvalidCredentials);

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
      throw new NotFoundException(AuthResponseMessage.RefreshTokenNotFound);

    if (refresh.ExpiredAt < DateTime.UtcNow)
      throw new BadRequestException(AuthResponseMessage.RefreshExpired);

    if (refresh.Action.Equals(TokenAction.REVOKE))
      throw new BadRequestException(AuthResponseMessage.RefreshTokenInvalid);

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

  public async Task<TokenDto> RefreshTokenAsync(string refreshToken, HttpResponse response)
  {
    var inCommingHashed = TokenHasher.Hash(refreshToken);
    var refresh = await service.GetRefreshTokenAsync(inCommingHashed);
    // Validate token
    if (string.IsNullOrWhiteSpace(refresh.HashedToken))
      throw new NotFoundException(AuthResponseMessage.RefreshTokenNotFound);

    if (refresh.ExpiredAt < DateTime.UtcNow)
      throw new BadRequestException(AuthResponseMessage.RefreshExpired);

    if (refresh.Action.Equals(TokenAction.REVOKE))
      throw new BadRequestException(AuthResponseMessage.RefreshTokenInvalid);

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
      token.AccessToken,
      token.RefreshToken,
      token.ExpiresAt
      );


  }
}
