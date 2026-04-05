using System;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Helpers;

public class DatabaseConnectionSettingHelper
{
  public static void DatabaseConnectionHelper(WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));
  }
}
