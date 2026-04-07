using System;
using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Application.Interfaces;

public interface IRefreshTokenAuditRepository
{
  Task AddAsync(string username, string hashedRefreshToken, TokenAction action, DateTime expiredAt);
  Task<RefreshToken> GetRefreshTokenAsync(string hash);
}
