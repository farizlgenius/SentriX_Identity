using System;
using Identity.Application.Interfaces;

namespace Identity.Infrastructure.Cache;

public sealed class NoCacheService : ICacheService
{
  public Task<T?> GetAsync<T>(string key) => Task.FromResult<T?>(default);

  public Task SetAsync<T>(string key, T value, TimeSpan expiry) => Task.CompletedTask;
}
