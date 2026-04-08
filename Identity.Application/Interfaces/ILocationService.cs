using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ILocationService
{
  Task<List<LocationDto>> GetAsync();
  Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize);
  Task<LocationDto> CreateAsync(LocationDto dto);
  Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize);
  Task<LocationDto> DeleteByIdAsync(int id);
  Task<LocationDto> UpdateAsync(LocationDto dto);
}
