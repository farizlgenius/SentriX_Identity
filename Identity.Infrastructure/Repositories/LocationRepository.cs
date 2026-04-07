using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class LocationRepository(AppDbContext context) : ILocationRepository
{
  public async Task<List<LocationDto>> GetAsync()
  {
    return await context.Locations
    .AsNoTracking()
    .Select(x => new LocationDto(x.id, x.name, x.description, x.country.name))
    .ToListAsync();

  }

  public async Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize)
  {
    var query = context.Locations.AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new LocationDto(x.id, x.name, x.description, x.country.name))
    .ToListAsync();

    return new PaginationDto<LocationDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }
}
