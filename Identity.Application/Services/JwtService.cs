using System;
using System.Text;
using Identity.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Identity.Domain.Entities;
using Identity.Application.Helpers;
using Identity.Domain.Enums;
using Identity.Application.DTOs;

namespace Identity.Application.Services;

public sealed class JwtService(IJwtData settings, IRefreshTokenAuditRepository repo) : IJwtService
{
  private readonly string _secretKey = settings.Secret;
  private readonly string _issuer = settings.Issuer;
  private readonly string _audience = settings.Audience;
  private readonly short _accessTokenMinutes = settings.AccessTokenMinutes;
  private readonly short _refreshTokenDays = settings.RefreshTokenDays;
  public async Task<Token> GenerateTokenAsync(UserInTokenDto user)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var now = DateTime.UtcNow;

    var claims = new[]
    {
      // Adding data to token claims (for demonstration, only username is added)
      new Claim("user_id",user.UserId),
      new Claim(JwtRegisteredClaimNames.Sub, user.Username),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

      // Authorized
      new Claim("role",user.RoleName),
      new Claim("role_id",user.RoleId.ToString()),
      new Claim("tenant_id",user.LocationId.ToString()),
      new Claim("tenant",user.LocationName)

    };

    var token = new JwtSecurityToken(
      issuer: _issuer,
      audience: _audience,
      claims: claims,
      notBefore: now,
      expires: now.AddMinutes(_accessTokenMinutes),
      signingCredentials: creds
    );

    // create random refresh token and store hashed in redis + audit in DB
    var rawRefresh = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    // Save Refresh Token in Redis with expiration (not implemented here, just a placeholder)
    await repo.AddAsync(user.Username, Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(rawRefresh))), Domain.Enums.TokenAction.CREATE, now.AddDays(_refreshTokenDays));

    return new Token(
      accessToken: new JwtSecurityTokenHandler().WriteToken(token),
      refreshToken: rawRefresh,
      expiresAt: _accessTokenMinutes,
      refreshExpireAt: now.AddDays(_refreshTokenDays)
    );
  }

  public async Task<Token> RefreshTokenAsync(RefreshToken refreshToken)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var now = DateTime.UtcNow;

    var claims = new[]
    {
      // Adding data to token claims (for demonstration, only username is added)
      new Claim(JwtRegisteredClaimNames.Sub, refreshToken.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

    };

    var res = new JwtSecurityToken(
      issuer: _issuer,
      audience: _audience,
      claims: claims,
      notBefore: now,
      expires: now.AddMinutes(_accessTokenMinutes),
      signingCredentials: creds
    );

    // create random refresh token and store hashed in redis + audit in DB
    var rawRefresh = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    // Save Refresh Token in Redis with expiration (not implemented here, just a placeholder)
    await repo.AddAsync(refreshToken.UserName, Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(rawRefresh))), Domain.Enums.TokenAction.ROTATE, now.AddDays(_refreshTokenDays));

    return new Token(
      accessToken: new JwtSecurityTokenHandler().WriteToken(res),
      refreshToken: rawRefresh,
      expiresAt: _accessTokenMinutes,
      refreshExpireAt: now.AddDays(_refreshTokenDays)
    );

  }

  public async Task<RefreshToken> GetRefreshTokenAsync(string hashed)
  {
    return await repo.GetRefreshTokenAsync(hashed);
  }

  public async Task<bool> RevokeTokenAsync(string refreshToken)
  {
    var hash = TokenHasher.Hash(refreshToken);
    await repo.AddAsync(string.Empty, hash, TokenAction.REVOKE, DateTime.UtcNow);

    // Remove from redis

    return true;
  }
}
