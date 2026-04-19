using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ILocationService
{
  Task<List<LocationDto>> GetAsync();
  Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize,string Search);
  Task<LocationDto> CreateAsync(CreateLocationDto dto);
  Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize);
  Task<LocationDto> DeleteByIdAsync(int id);
  Task<LocationDto> UpdateAsync(LocationDto dto);
  Task<List<LocationDto>> GetRangeLocationAsync(RangeIdDto dto);
  Task<List<CountryDto>> GetAllCountriesAsync();
  Task<List<LocationDto>> DeleteRangeAsync(RangeIdDto dto);
}
