using System;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public sealed class ApiKeyService(IApiKeyRepository repo) : IApiKeyService
{
  public async Task<ApiKey> ValidateApiKeyAsync(string apiKey)
  {
    return await repo.ValidateApiKeyAsync(apiKey);
  }
}
