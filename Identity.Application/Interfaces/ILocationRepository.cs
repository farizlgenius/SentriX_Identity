using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface ILocationRepository
{
  Task<List<LocationDto>> GetAsync();
  Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize, string Search);
  Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize);
  Task<bool> IsAnyNameAsync(string name);
  Task<LocationDto> AddAsync(Location location);
  Task<bool> IsValidCountryAsync(int id);
  Task<bool> IsAnyByIdAsync(int id);
  Task<LocationDto> DeleteByIdAsync(int id);
  Task<LocationDto> UpdateAsync(Location location);
  Task<List<LocationDto>> GetRangeLocationAsync(List<int> ids);
  Task<List<CountryDto>> GetAllCountriesAsync();
  Task<bool> IsAllExistByIdsAsync(List<int> ids);
  Task<List<LocationDto>> DeleteRangeAsync(List<int> ids);
}
