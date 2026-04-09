using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class CompanyRepository(AppDbContext context) : ICompanyRepository
{
      public async Task<CompanyDto> AddAsync(Company domain)
      {
            var data = await context.Companies.AddAsync(
                  new Persistence.Entities.Company(domain)
            );
            var save = await context.SaveChangesAsync();
            if (data is null || save <= 0)
                  throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

            return new CompanyDto(
              data.Entity.name,
              data.Entity.description,
              data.Entity.address,
              data.Entity.location_id,
            await context.Locations.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.location_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
            , data.Entity.id);
      }

      public async Task<CompanyDto> DeleteByIdAsync(int id)
      {
            var entity = await context.Companies.FirstOrDefaultAsync(c => c.id == id);
            if (entity is null)
                  throw new BadRequestException(DbExceptionMessage.RecordNotFound);
            var data = context.Companies.Remove(entity);
            var save = await context.SaveChangesAsync();

            return new CompanyDto(
              data.Entity.name,
              data.Entity.description,
              data.Entity.address,
              data.Entity.location_id,
            await context.Locations.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.location_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
            , data.Entity.id);

      }



      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize)
      {
            var query = context.Companies.AsNoTracking().AsQueryable();
            var totalItems = await query.CountAsync();
            var items = await query
                  .OrderByDescending(x => x.id)
                  .Skip((Page - 1) * PageSize)
                  .Take(PageSize)
                  .Select(x => new CompanyDto(x.name, x.address, x.description, x.location_id, x.location.name, x.id))
                  .ToListAsync();

            return new PaginationDto<CompanyDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
      }

      public async Task<bool> IsAnyLocationWithIdAsync(int LocationId)
      {
            return await context.Locations.AsNoTracking().AnyAsync(x => x.id == LocationId);
      }

      public async Task<bool> IsAnyWithIdAsync(int id)
      {
            return await context.Companies.AsNoTracking().AnyAsync(c => c.id == id);
      }

      public async Task<CompanyDto> UpdateAsync(Company domain)
      {
            var entity = await context.Companies.FirstOrDefaultAsync(c => c.id == domain.Id);
            if (entity is null)
                  throw new BadRequestException(DbExceptionMessage.RecordNotFound);
            entity.Update(domain);
            var data = context.Companies.Update(entity);
            var save = await context.SaveChangesAsync();

            return new CompanyDto(
              data.Entity.name,
              data.Entity.description,
              data.Entity.address,
              data.Entity.location_id,
            await context.Locations.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.location_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
            , data.Entity.id);
      }
}
