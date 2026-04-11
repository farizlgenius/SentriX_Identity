using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class AuthRepository(AppDbContext context) : IAuthRepository
{
  public async Task<bool> IsAnyUserExistsAsync(string username)
  {
    return await context.Operators.AsNoTracking().AnyAsync(u => u.username == username);
  }

  public async Task<string> GetUserHashPasswordAsync(string username)
  {
    var pass = await context.Operators.AsNoTracking()
    .Where(u => u.username == username)
    .Select(u => u.password)
    .FirstOrDefaultAsync();

    if (string.IsNullOrWhiteSpace(pass))
      return string.Empty;

    return pass;
  }

  public async Task<UserInTokenDto> GetUserByUsernameAsync(string username)
  {
    return await context.Operators
    .AsNoTracking()
    .OrderBy(x => x.id)
    .Where(x => x.username.Equals(username))
    .Select(u => new UserInTokenDto(
      u.operator_id,
      u.username,
      u.role.id,
      u.role.name,
      u.operator_locations.ElementAt(0).location_id,
      u.operator_locations.ElementAt(0).location.name
    )).FirstOrDefaultAsync() ?? new UserInTokenDto(
      string.Empty,
      string.Empty,
      0,
      string.Empty,
      0,
      string.Empty
      );
  }

  public async Task<List<int>> GetLocationsByUsernameAsync(string username)
  {
    return await context.Operators.AsNoTracking()
    .Where(u => u.username.Equals(username))
    .SelectMany(u => u.operator_locations)
    .Select(i => i.location_id)
    .ToListAsync();

  }

  public async Task<List<PermissionDto>> GetPermissionsByRoleIdAsync(int roleId)
  {
    return await context.Roles
    .AsNoTracking()
    .Where(r => r.id == roleId)
    .SelectMany(r => r.permissions)
    .Select(p => new PermissionDto(p.feature_id, p.feature.name, p.is_enabled, p.is_created, p.is_updated, p.is_deleted))
    .ToListAsync();
  }
}
