using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class LocationRepository(AppDbContext context) : ILocationRepository
{
  public async Task<LocationDto> AddAsync(Location location)
  {
    var data = await context.Locations.AddAsync(new Persistence.Entities.Location(location));
    await context.SaveChangesAsync();
    if (data is null)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new LocationDto(
      data.Entity.name,
      data.Entity.description,
      data.Entity.country_id,
    await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
    , data.Entity.id);

  }

  public async Task<List<LocationDto>> GetAsync()
  {
    return await context.Locations
    .AsNoTracking()
    .Select(x => new LocationDto(x.name, x.description, x.country_id, x.country.name, x.id))
    .ToListAsync();

  }

  public async Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize)
  {
    var query = context.Locations.AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new CountryDto(x.id, x.name, x.description))
    .ToListAsync();

    return new PaginationDto<CountryDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize)
  {
    var query = context.Locations.AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new LocationDto(x.name, x.description, x.country_id, x.country.name, x.id))
    .ToListAsync();

    return new PaginationDto<LocationDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<bool> IsAnyNameAsync(string name)
  {
    return await context.Locations.AsNoTracking()
    .AnyAsync(l => l.name.ToLower().Equals(name.Trim().ToLower()));
  }

  public async Task<bool> IsValidCountryAsync(int id)
  {
    return await context.Countries.AsNoTracking()
    .AnyAsync(c => c.id == id);
  }
}
