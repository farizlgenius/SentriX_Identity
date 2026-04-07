using System;
using Identity.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Identity.Application.Interfaces;

public interface IAuthService
{
  Task<BaseDto> LoginAsync(LoginDto loginDto, HttpResponse httpResponse);
  Task<BaseDto> RefreshTokenAsync(string refreshToken, HttpResponse httpResponse);
  Task<BaseDto> LogoutAsync(string refreshToken, HttpResponse response);
  Task<BaseDto> GetMeByUsernameAndRoleIdAsync(string username, int roleId);

}
