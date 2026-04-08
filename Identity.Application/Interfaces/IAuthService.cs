using System;
using Identity.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Identity.Application.Interfaces;

public interface IAuthService
{
  Task<TokenDto> LoginAsync(LoginDto loginDto, HttpResponse httpResponse);
  Task<TokenDto> RefreshTokenAsync(string refreshToken, HttpResponse httpResponse);
  Task<BaseDto> LogoutAsync(string refreshToken, HttpResponse response);
  Task<MeDto> GetMeByUsernameAndRoleIdAsync(string username, int roleId);

}
