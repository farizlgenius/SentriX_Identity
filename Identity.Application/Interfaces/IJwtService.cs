using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IJwtService
{
  Task<Token> GenerateTokenAsync(UserInTokenDto user);
  Task<Token> RefreshTokenAsync(RefreshToken refreshToken);
  Task<bool> RevokeTokenAsync(string refreshToken);
  Task<RefreshToken> GetRefreshTokenAsync(string hashed);
}
