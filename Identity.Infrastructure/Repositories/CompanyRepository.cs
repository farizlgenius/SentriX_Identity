using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class CompanyRepository(AppDbContext context) : ICompanyRepository
{
      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize)
      {
            var query = context.Companies.AsNoTracking().AsQueryable();
            var totalItems = await query.CountAsync();
            var items = await query
                  .OrderByDescending(x => x.id)
                  .Skip((Page - 1) * PageSize)
                  .Take(PageSize)
                  .Select(x => new CompanyDto(x.name,x.address,x.description,x.id))
                  .ToListAsync();

            return new PaginationDto<CompanyDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
      }

      public async Task<bool> IsAnyLocationWithIdAsync(int LocationId)
      {
            return await context.Locations.AsNoTracking().AnyAsync(x => x.id == LocationId);
      }
}
