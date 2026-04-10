using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class RoleRepository(AppDbContext context) : IRoleRepository
{
  public async Task<RoleDto> AddAsync(Role domain)
  {
    var data = await context.Roles.AddAsync(
      new Persistence.Entities.Role(domain)
    );
    data.Entity.AddPermissions(domain.Permissions);
    var save = await context.SaveChangesAsync();

    if (data.Entity == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new RoleDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.permissions
      .Select(r => new PermissionDto(r.feature_id,
        context.Features.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == r.feature_id).Select(x => x.name).FirstOrDefault() ?? "",
      r.is_enabled,
      r.is_created,
      r.is_updated,
      r.is_deleted))
      .ToList(),
      context.Locations.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == data.Entity.location_id).Select(x => x.name).FirstOrDefault() ?? ""
      );
  }

  public async Task<RoleDto> DeleteByIdAsync(int id)
  {
    var entity = await context.Roles.OrderByDescending(r => r.id).Where(r => r.id == id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var data = context.Roles.Remove(entity);
    var save = await context.SaveChangesAsync();

    if (data.Entity == null || save <= 0)
      throw new Exception(DbExceptionMessage.DeleteRecordUnsuccessful);

    return new RoleDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.permissions
      .Select(r => new PermissionDto(r.feature_id,
        context.Features.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == r.feature_id).Select(x => x.name).FirstOrDefault() ?? "",
      r.is_enabled,
      r.is_created,
      r.is_updated,
      r.is_deleted))
      .ToList(),
      context.Locations.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == data.Entity.location_id).Select(x => x.name).FirstOrDefault() ?? ""
      );

  }

  public async Task<PaginationDto<RoleDto>> GetPaginationWithLocationIdAsync(int LocationId, int Page, int PageSize)
  {
    var query = context.Roles.AsNoTracking().AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query.OrderByDescending(r => r.id)
    .Where(r => r.location_id == LocationId)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(r => new RoleDto(r.id, r.name, r.permissions.Select(p => new PermissionDto(p.feature_id, p.feature.name, p.is_enabled, p.is_created, p.is_updated, p.is_deleted)).ToList(), r.location.name))
    .ToListAsync();

    return new PaginationDto<RoleDto>(Page, PageSize, totalItems,
    (int)Math.Ceiling(totalItems / (double)PageSize)
    , items);
  }

  public async Task<bool> IsAnyLocationIdAsync(int LocationId)
  {
    return await context.Locations.AsNoTracking().AnyAsync(l => l.id == LocationId);
  }

  public async Task<bool> IsAnyNameWithLocationIdAsync(int LocationId, string Name)
  {
    return await context.Roles.AsNoTracking().AnyAsync(r => r.location_id == LocationId && r.name.Equals(Name));
  }

  public async Task<bool> IsAnyWithIdAsync(int id)
  {
    return await context.Roles.AsNoTracking().AnyAsync(r => r.id == id);
  }

  public async Task<RoleDto> UpdateAsync(Role domain)
  {
    var entity = await context.Roles.OrderByDescending(r => r.id).Where(r => r.id == domain.Id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    // Delete Relate Permissions
    var old = await context.Permissions.Where(p => p.role_id == domain.Id).ToArrayAsync();
    context.Permissions.RemoveRange(old);
    var save = await context.SaveChangesAsync();

    if (save < 0)
      throw new Exception(DbExceptionMessage.DeleteRelateRecordUnsuccessful);

    entity.Update(domain);

    var data = context.Roles.Update(entity);
    save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.UpdateRecordUnsuccessful);

    return new RoleDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.permissions
      .Select(r => new PermissionDto(r.feature_id,
        context.Features.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == r.feature_id).Select(x => x.name).FirstOrDefault() ?? "",
      r.is_enabled,
      r.is_created,
      r.is_updated,
      r.is_deleted))
      .ToList(),
      context.Locations.AsNoTracking().OrderByDescending(x => x.id).Where(x => x.id == data.Entity.location_id).Select(x => x.name).FirstOrDefault() ?? ""
      );
  }
}
