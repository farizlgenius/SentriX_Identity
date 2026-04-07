using System;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class RefreshTokenAuditRepository(AppDbContext context) : IRefreshTokenAuditRepository
{
  public async Task AddAsync(string username, string hashedRefreshToken, TokenAction action, DateTime expiredAt)
  {
    var audit = new Persistence.Entities.RefreshTokenAudit
    {
      username = username,
      hashed_refresh_token = hashedRefreshToken,
      action = action,
      expired_at = expiredAt
    };

    await context.RefreshTokenAudits.AddAsync(audit);
    await context.SaveChangesAsync();
  }

  public async Task<RefreshToken> GetRefreshTokenAsync(string hash)
  {
    return await context.RefreshTokenAudits
    .AsNoTracking()
    .OrderBy(x => x.id)
    .Where(x => x.hashed_refresh_token.Equals(hash))
    .Select(x => new RefreshToken(x.hashed_refresh_token, x.username, x.username, x.action, x.expired_at))
    .FirstOrDefaultAsync() ??
    new RefreshToken(string.Empty, string.Empty, string.Empty, TokenAction.CREATE, DateTime.UtcNow)
    ;
  }

}
