using System;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IApiKeyService
{
  Task<ApiKey> ValidateApiKeyAsync(string apiKey);
}
