using System;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class ApiKeyRepository(AppDbContext context) : IApiKeyRepository
{
  public async Task<Identity.Domain.Entities.ApiKey> ValidateApiKeyAsync(string apiKey)
  {
    return await context.ApiKeys
      .AsNoTracking()
      .OrderBy(x => x.created_at)
      .Where(x => x.key.Equals(apiKey))
      .Select(x => new Identity.Domain.Entities.ApiKey(x.key, x.owner, x.is_active, x.ExpireAt))
      .FirstOrDefaultAsync() ?? new Identity.Domain.Entities.ApiKey(string.Empty, string.Empty, false, DateTime.MinValue);
  }
}
