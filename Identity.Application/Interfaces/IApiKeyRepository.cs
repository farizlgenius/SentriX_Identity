using System;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IApiKeyRepository
{
  Task<ApiKey> ValidateApiKeyAsync(string apiKey);
}
