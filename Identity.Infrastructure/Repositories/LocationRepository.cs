using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
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
    var save = await context.SaveChangesAsync();
    if (data is null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new LocationDto(
      data.Entity.name,
      data.Entity.description,
      data.Entity.country_id,
    await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
    , data.Entity.id);

  }

  public async Task<LocationDto> DeleteByIdAsync(int id)
  {
    var record = await context.Locations.OrderByDescending(l => l.id).FirstOrDefaultAsync(l => l.id == id);
    if (record is null)
      throw new NotFoundException(LocationResponseMessage.LocationNotFound);
    var data = context.Locations.Remove(record);
    var save = await context.SaveChangesAsync();
    if (data is null || save <= 0)
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
    var query = context.Countries.AsNoTracking().AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new CountryDto(x.id, x.name, x.code))
    .ToListAsync();

    return new PaginationDto<CountryDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize)
  {
    var query = context.Locations.AsNoTracking().AsQueryable();
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new LocationDto(x.name, x.description, x.country_id, x.country.name, x.id))
    .ToListAsync();

    return new PaginationDto<LocationDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<bool> IsAnyByIdAsync(int id)
  {
    return await context.Locations.AsNoTracking()
    .AnyAsync(l => l.id == id);
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

  public async Task<LocationDto> UpdateAsync(Location location)
  {
    var record = await context.Locations.OrderByDescending(l => l.id).FirstOrDefaultAsync(l => l.id == location.Id);
    if (record is null)
      throw new NotFoundException(LocationResponseMessage.LocationNotFound);

    record.Update(location);

    var data = context.Locations.Update(record);
    var save = await context.SaveChangesAsync();
    if (data is null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);


    return new LocationDto(
      data.Entity.name,
      data.Entity.description,
      data.Entity.country_id,
    await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? ""
    , data.Entity.id);

  }
}
