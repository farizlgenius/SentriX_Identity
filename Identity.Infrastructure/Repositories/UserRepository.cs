using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class OperatorRepository(AppDbContext context) : IOperatorRepository
{
  public async Task<OperatorDto> AddAsync(Operator domain)
  {
    var data = await context.Operators.AddAsync(
     new Persistence.Entities.Operator(domain)
   );

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    data.Entity.AddPassword(domain.Password);
    data.Entity.AddLocation(data.Entity.id, domain.LocationId);
    save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new OperatorDto(
      data.Entity.id,
      data.Entity.operator_id,
      data.Entity.username,
      data.Entity.title,
      data.Entity.firstname,
      data.Entity.middlename,
      data.Entity.lastname,
      data.Entity.gender,
      data.Entity.email,
      data.Entity.mobile,
      await context.Roles.AsNoTracking().OrderByDescending(x => x.id).Where(c => c.users.Select(x => x.id).Contains(data.Entity.id)).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

  public async Task<OperatorDto> DeleteByIdAsync(int id)
  {
    var entity = await context.Operators.OrderByDescending(u => u.id).Where(u => u.id == id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var data = context.Operators.Remove(entity);
    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.UpdateRecordUnsuccessful);

    return new OperatorDto(
      data.Entity.id,
      data.Entity.operator_id,
      data.Entity.username,
      data.Entity.title,
      data.Entity.firstname,
      data.Entity.middlename,
      data.Entity.lastname,
      data.Entity.gender,
      data.Entity.email,
      data.Entity.mobile,
      await context.Roles.AsNoTracking().OrderByDescending(x => x.id).Where(c => c.users.Select(x => x.id).Contains(data.Entity.id)).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

  public async Task<PaginationDto<OperatorDto>> GetPaginationWithLocationIdAsync(int LocationId, int Page, int PageSize)
  {
    var query = context.Operators.AsNoTracking().AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query.OrderByDescending(u => u.id)
    .Where(u => u.operator_locations.Select(ul => ul.location_id).Contains(LocationId))
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(u =>
    new OperatorDto(
      u.id,
      u.operator_id,
      u.username,
      u.title,
      u.firstname,
      u.middlename,
      u.lastname,
      u.gender,
      u.email,
      u.mobile,
       u.role.name
      ))
    .ToListAsync();

    return new PaginationDto<OperatorDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<bool> IsAnyByIdAsync(int id)
  {
    return await context.Operators.AsNoTracking().AnyAsync(u => u.id == id);
  }

  public async Task<bool> IsAnyUserIdAsync(string UserId)
  {
    return await context.Operators.AsNoTracking().AnyAsync(x => x.operator_id.Equals(UserId));
  }

  public async Task<bool> IsAnyUsernameAsync(string Username)
  {
    return await context.Operators.AsNoTracking().AnyAsync(u => u.username.Equals(Username));
  }

  public async Task<bool> IsAnyWithLocationIdAsync(int LocationId)
  {
    return await context.Locations.AsNoTracking().AnyAsync(l => l.id == LocationId);
  }

  public async Task<bool> IsValidCompanyAsync(int CompanyId)
  {
    return await context.Companies.AsNoTracking().AnyAsync(c => c.id == CompanyId);
  }

  public async Task<bool> IsValidDepartmentAsync(int DepartmentId)
  {
    return await context.Departments.AsNoTracking().AnyAsync(d => d.id == DepartmentId);
  }

  public async Task<bool> IsExceptLocationIdsAsync(List<int> LocationIds)
  {
    var existingIds = await context.Locations
        .Where(x => LocationIds.Contains(x.id))
        .Select(x => x.id)
        .ToListAsync();

    return LocationIds.Except(existingIds).Any();
  }

  public async Task<bool> IsValidPositionAsync(int PositionId)
  {
    return await context.Positions.AsNoTracking().AnyAsync(p => p.id == PositionId);
  }

  public async Task<OperatorDto> UpdateAsync(Operator domain)
  {
    var entity = await context.Operators.OrderByDescending(u => u.id).Where(u => u.id == domain.Id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    entity.Update(domain);
    var data = context.Operators.Update(entity);
    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.UpdateRecordUnsuccessful);

    return new OperatorDto(
      data.Entity.id,
      data.Entity.operator_id,
      data.Entity.username,
      data.Entity.title,
      data.Entity.firstname,
      data.Entity.middlename,
      data.Entity.lastname,
      data.Entity.gender,
      data.Entity.email,
      data.Entity.mobile,
      await context.Roles.AsNoTracking().OrderByDescending(x => x.id).Where(c => c.users.Select(x => x.id).Contains(data.Entity.id)).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

  public async Task<bool> IsValidRoleIdAsync(int RoleId)
  {
    return await context.Roles.AsNoTracking().AnyAsync(x => x.id == RoleId);
  }
}
