using System;
using Identity.Application.Interfaces;
using Identity.Application.Services;
using Identity.Infrastructure.Repositories;

namespace Identity.Api.Helpers;

public class DISettingHelper
{
  public static void DISetting(WebApplicationBuilder builder)
  {
    // ==========================
    // Adding App Dependency Injection
    // ==========================
    builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
    builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
    // // DI
    // builder.Services.AddHttpClient();
    // builder.Services.AddScoped<ICache, CacheRepository>();
    // builder.Services.AddTransient<ExceptionHandlingMiddleware>();

    // // DI Service
    // builder.Services.AddScoped<IAuth, AuthService>();
    // builder.Services.AddScoped<IRole, RoleService>();
    // builder.Services.AddScoped<IOperator, OperatorService>();

    // // DI Repository
    // builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    // builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
    // builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
    // builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    // builder.Services.AddScoped<ITokenRepository, TokenRepository>();
    // builder.Services.AddScoped<IHttpRepository, HttpRepository>();

  }

}
