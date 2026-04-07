using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ILocationRepository
{
  Task<List<LocationDto>> GetAsync();
  Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize);
}
