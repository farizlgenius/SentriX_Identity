using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class PositionRepository(AppDbContext context) : IPositionRepository
{
      public async Task<PositionDto> AddAsync(Position domain)
      {
            var data = await context.Positions.AddAsync(
                  new Persistence.Entities.Position(domain.Name,domain.Description,domain.DepartmentId)
            );
            var save = await context.SaveChangesAsync();
            if(data == null || save <= 0)
                  throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

            return new PositionDto(data.Entity.id, data.Entity.name, data.Entity.description, data.Entity.department_id, 
                  await context.Departments.AsNoTracking().OrderByDescending(d => d.id).Where(d => d.id == data.Entity.department_id).Select(d => d.name).FirstOrDefaultAsync() ?? ""
            );
      }

      public async Task<PositionDto> DeleteByIdAsync(int id)
      {
            var entity = await context.Positions.OrderByDescending(p => p.id).FirstOrDefaultAsync(p => p.id == id);
            if(entity == null)
                  throw new BadRequestException(DbExceptionMessage.RecordNotFound);
            var data = context.Positions.Remove(entity);
            var save = await context.SaveChangesAsync();

             if(data == null || save <= 0)
                  throw new Exception(DbExceptionMessage.DeleteRecordUnsuccessful);

            return new PositionDto(data.Entity.id, data.Entity.name, data.Entity.description, data.Entity.department_id, 
                  await context.Departments.AsNoTracking().OrderByDescending(d => d.id).Where(d => d.id == data.Entity.department_id).Select(d => d.name).FirstOrDefaultAsync() ?? ""
            );

      }

      public async Task<PaginationDto<PositionDto>> GetPaginationWithDepartmentIdAsync(int DepartmentId, int Page, int PageSize)
      {
            if(!await context.Departments.AsNoTracking().AnyAsync(d => d.id == DepartmentId))
                  throw new BadRequestException(DbExceptionMessage.QueryIdInvalid);

            var query = context.Positions.AsNoTracking().AsQueryable();
            var totalItems = await query.CountAsync();
            var items = await query.Where(p => p.department_id == DepartmentId)
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .Select(p => new PositionDto(p.id,p.name,p.description,p.department_id,p.department.name)).ToListAsync();

            return new PaginationDto<PositionDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
      }

      public async Task<bool> IsAnyWithDepartmentIdAsync(int DepartmentId)
      {
            return await context.Departments.AsNoTracking().AnyAsync(p => p.id == DepartmentId);
      }

      public async Task<bool> IsAnyWithIdAsync(int id)
      {
            return await context.Positions.AsNoTracking().AnyAsync(p => p.id == id);
      }

      public async Task<bool> IsAnyWithNameAsync(string Name)
      {
            return await context.Positions.AsNoTracking().AnyAsync(p => p.name.Equals(Name));
      }

      public async Task<PositionDto> UpdateAsync(Position domain)
      {
            var entity = await context.Positions.OrderByDescending(p => p.id).FirstOrDefaultAsync(p => p.id == domain.Id);
            if(entity == null)
                  throw new BadRequestException(DbExceptionMessage.RecordNotFound);
            
            entity.Update(domain);
            var data = context.Positions.Update(entity);
            var save = await context.SaveChangesAsync();

            return new PositionDto(data.Entity.id, data.Entity.name, data.Entity.description, data.Entity.department_id, 
                  await context.Departments.AsNoTracking().OrderByDescending(d => d.id).Where(d => d.id == data.Entity.department_id).Select(d => d.name).FirstOrDefaultAsync() ?? ""
            );
      }
}
