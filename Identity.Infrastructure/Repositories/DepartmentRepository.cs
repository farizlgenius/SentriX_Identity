using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
{
  public async Task<DepartmentDto> AddAsync(Department domain)
  {
    var data = await context.Departments.AddAsync(
      new Persistence.Entities.Department(domain)
    );
    var save = await context.SaveChangesAsync();

    if (data.Entity == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DepartmentDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.description,
      data.Entity.company_id,
      await context.Companies.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.company_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

  public async Task<DepartmentDto> DeleteByIdAsync(int id)
  {
    var entity = await context.Departments.FirstOrDefaultAsync(d => d.id == id);
    if (entity is null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var data = context.Departments.Remove(entity);
    var save = await context.SaveChangesAsync();

    if (data.Entity == null || save <= 0)
      throw new Exception(DbExceptionMessage.DeleteRecordUnsuccessful);

    return new DepartmentDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.description,
      data.Entity.company_id,
      await context.Companies.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.company_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

  public async Task<PaginationDto<DepartmentDto>> GetPaginationByCompanyIdAsync(int companyId, int page, int pageSize,string Search)
  {
    var query = context.Departments.AsNoTracking().Where(x => x.company_id == companyId).AsQueryable();

    if (!string.IsNullOrWhiteSpace(Search))
    {
      var search = Search.Trim();

      if (context.Database.IsNpgsql())
      {
        var pattern = $"%{search}%";

        query = query.Where(x =>
            EF.Functions.ILike(x.name, pattern) ||
            EF.Functions.ILike(x.description, pattern) 
        );
      }
      else // SQL Server
      {
        query = query.Where(x =>
            x.name.Contains(search) ||
            x.description.Contains(search) 
        );
      }
    }


    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(d => d.id)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .Select(d => new DepartmentDto(d.id, d.name, d.description, d.company_id, d.company.name))
    .ToListAsync();

    return new PaginationDto<DepartmentDto>(page, pageSize, totalItems, (int)Math.Ceiling(totalItems / (double)pageSize), items);
  }

  public async Task<bool> IsAnyComanyWithIdAsync(int id)
  {
    return await context.Companies.AsNoTracking().AnyAsync(c => c.id == id);
  }

  public async Task<bool> IsAnyWithIdAsync(int id)
  {
    return await context.Departments.AsNoTracking().AnyAsync(d => d.id == id);
  }

  public async Task<bool> IsAnyWithNameAsync(string name)
  {
    return await context.Departments.AsNoTracking().AnyAsync(d => d.name.Equals(name));
  }

  public async Task<DepartmentDto> UpdateAsync(Department domain)
  {
    var entity = await context.Departments.FirstOrDefaultAsync(d => d.id == domain.Id);
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var dom = new Department(domain.Id, domain.Name, domain.Description, domain.CompanyId);

    entity.Update(dom);

    var data = context.Departments.Update(entity);
    var save = await context.SaveChangesAsync();

    if (data.Entity == null || save <= 0)
      throw new Exception(DbExceptionMessage.UpdateRecordUnsuccessful);

    return new DepartmentDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.description,
      data.Entity.company_id,
      await context.Companies.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.company_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
      );
  }

   public async Task<bool> IsAllExistByIdsAsync(List<int> ids)
      {
            var count = await context.Departments
       .AsNoTracking()
       .Where(l => ids.Contains(l.id))
       .CountAsync();

            return count == ids.Count;
      }

      public async Task<List<DepartmentDto>> DeleteRangeAsync(List<int> ids)
      {

            var records = await context.Departments.Where(l => ids.Contains(l.id)).ToListAsync();
            if (records is null || records.Count == 0)
                  throw new Exception(DbExceptionMessage.RecordNotFound);

            context.Departments.RemoveRange(records);
            var save = await context.SaveChangesAsync();
            if (save <= 0)
                  throw new Exception(DbExceptionMessage.DeleteRecordUnsuccessful);

            return records.Select(data => new DepartmentDto(
              data.id,
              data.name,
              data.description,
              data.company_id,
              context.Companies.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.company_id).Select(c => c.name).FirstOrDefault() ?? ""
              )).ToList();


      }

      public async Task<List<DepartmentDto>> GetByCompanyIdAsync(int id)
      {
            return await context.Departments
       .AsNoTracking()
       .Where(d => d.company_id == id)
       .OrderByDescending(d => d.id)
       .Select(d => new DepartmentDto(d.id, d.name, d.description, d.company_id, d.company.name))
       .ToListAsync();
      }
}
