using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface ILocationRepository
{
  Task<List<LocationDto>> GetAsync();
  Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize);
  Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize);
  Task<bool> IsAnyNameAsync(string name);
  Task<LocationDto> AddAsync(Location location);
  Task<bool> IsValidCountryAsync(int id);
}
