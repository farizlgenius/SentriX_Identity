using System;
using Identity.Application.Interfaces;
using Identity.Application.Settings;
using Identity.Infrastructure.Cache;
using StackExchange.Redis;

namespace Identity.Api.Helpers;

public class CacheSettingHelper
{
  public static void RedisConfiguration(WebApplicationBuilder builder)
  {
    // builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    // {
    //   var configuration = builder.Configuration.GetSection("Redis")["ConnectionStirng"] ?? "localhost:6379";
    //   return ConnectionMultiplexer.Connect(configuration);
    // });

    var redisOptions = builder.Configuration
    .GetSection("Redis")
    .Get<RedisSettings>();


    // If Redis disabled → use NoCache
    if (redisOptions?.Enabled != true)
    {
      Console.WriteLine("ℹ️ Redis disabled");
      builder.Services.AddSingleton<ICacheService, NoCacheService>();
    }

    try
    {
      var muxer = ConnectionMultiplexer.Connect(redisOptions?.ConnectionString ?? "localhost:6379");
      builder.Services.AddSingleton<IConnectionMultiplexer>(muxer);
      builder.Services.AddSingleton<ICacheService, CacheService>();

      Console.WriteLine("✅ Redis connected");
    }
    catch
    {
      Console.WriteLine("⚠️ Redis unavailable → NoCacheService used");
      builder.Services.AddSingleton<ICacheService, NoCacheService>();
    }


  }
}
