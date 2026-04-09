using System;
using Identity.Api.Middlewares;
using Identity.Application.Interfaces;
using Identity.Application.Services;
using Identity.Application.Settings;
using Identity.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace Identity.Api.Helpers;

public class DISettingHelper
{
  public static void DISetting(WebApplicationBuilder builder)
  {
    // ==========================
    // Adding Repository
    // ==========================
    builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
    builder.Services.AddScoped<IRefreshTokenAuditRepository, RefreshTokenAuditRepository>();
    builder.Services.AddScoped<ILocationRepository, LocationRepository>();
    builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

    // ==========================
    // Adding Service
    // ==========================
    builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IJwtService, JwtService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<ILocationService, LocationService>();
    builder.Services.AddScoped<ICompanyService, CompanyService>();

    // ==========================
    // Custom Service
    // ==========================
    builder.Services.AddTransient<GlobalException>();

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
