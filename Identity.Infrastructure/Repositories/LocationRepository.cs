using System;
using System.Text;
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

    var data2 = await context.OperatorLocations.AddAsync(new Persistence.Entities.OperatorLocation
    {
      location_id = data.Entity.id,
      operator_id = 1 // Default operator id, should be replaced with actual operator id from context
    });
    var save2 = await context.SaveChangesAsync();

    if (data2 is null || save2 <= 0)
      throw new Exception(DbExceptionMessage.CreateReferenceRecordUnsuccessful);

    await context.SaveChangesAsync();

    return new LocationDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.description,
      data.Entity.country_id,
    await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? "");

  }

  public async Task<LocationDto> DeleteByIdAsync(int id)
  {
    var record = await context.Locations.OrderByDescending(l => l.id).FirstOrDefaultAsync(l => l.id == id);
    if (record is null)
      throw new NotFoundException(DbExceptionMessage.RecordNotFound);
    var data = context.Locations.Remove(record);
    var save = await context.SaveChangesAsync();
    if (data is null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new LocationDto(
  data.Entity.id,
  data.Entity.name,
  data.Entity.description,
  data.Entity.country_id,
await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? "");

  }

  public async Task<List<LocationDto>> DeleteRangeAsync(List<int> ids)
  {

    var records = await context.Locations.Where(l => ids.Contains(l.id)).ToListAsync();
    if (records is null || records.Count == 0)
      throw new NotFoundException(DbExceptionMessage.RecordNotFound);

    context.Locations.RemoveRange(records);
    var save = await context.SaveChangesAsync();
    if (save <= 0)
      throw new Exception(DbExceptionMessage.DeleteRecordUnsuccessful);

    return records.Select(data => new LocationDto(
      data.id,
      data.name,
      data.description,
      data.country_id,
    context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.country_id).Select(c => c.name).FirstOrDefault() ?? "")).ToList();


  }

  public async Task<List<CountryDto>> GetAllCountriesAsync()
  {
    return await context.Countries
        .AsNoTracking()
        .Select(x => new CountryDto(x.id, x.name, x.code))
        .ToListAsync();
  }

  public async Task<List<LocationDto>> GetAsync()
  {
    return await context.Locations
    .AsNoTracking()
    .Select(x => new LocationDto(x.id, x.name, x.description, x.country_id, x.country.name))
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

  public async Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize, string Search)
  {
    var query = context.Locations.AsNoTracking().AsQueryable();
    
    if (!string.IsNullOrWhiteSpace(Search))
    {
      var search = Search.Trim();

      if (context.Database.IsNpgsql())
      {
        var pattern = $"%{search}%";

        query = query.Where(x =>
            EF.Functions.ILike(x.name, pattern) ||
            EF.Functions.ILike(x.description, pattern) ||
            EF.Functions.ILike(x.country.name, pattern)
        );
      }
      else // SQL Server
      {
        query = query.Where(x =>
            x.name.Contains(search) ||
            x.description.Contains(search) ||
            x.country.name.Contains(search)
        );
      }
    }
    var totalItems = await query.CountAsync();
    var items = await query
    .OrderByDescending(x => x.id)
    .Skip((Page - 1) * PageSize)
    .Take(PageSize)
    .Select(x => new LocationDto(x.id, x.name, x.description, x.country_id, x.country.name))
    .ToListAsync();

    return new PaginationDto<LocationDto>(Page, PageSize, totalItems, (int)Math.Ceiling(totalItems / (double)PageSize), items);
  }

  public async Task<List<LocationDto>> GetRangeLocationAsync(List<int> ids)
  {
    var locations = await context.Locations
        .AsNoTracking()
        .OrderBy(l => l.id)
        .Where(l => ids.Contains(l.id))
        .Select(x => new LocationDto(x.id, x.name, x.description, x.country_id, x.country.name))
        .ToListAsync();

    return locations;
  }

  public async Task<bool> IsAllExistByIdsAsync(List<int> ids)
  {
    var count = await context.Locations
        .AsNoTracking()
        .Where(l => ids.Contains(l.id))
        .CountAsync();

    return count == ids.Count;
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
      throw new NotFoundException(DbExceptionMessage.RecordNotFound);

    record.Update(location);

    var data = context.Locations.Update(record);
    var save = await context.SaveChangesAsync();
    if (data is null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);


    return new LocationDto(
  data.Entity.id,
  data.Entity.name,
  data.Entity.description,
  data.Entity.country_id,
await context.Countries.AsNoTracking().OrderByDescending(c => c.id).Where(c => c.id == data.Entity.country_id).Select(c => c.name).FirstOrDefaultAsync() ?? "");


  }
}
