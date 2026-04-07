using System;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;

namespace Identity.Application.Services;

public class LocationService(ILocationRepository repo) : ILocationService
{
  public async Task<List<LocationDto>> GetAsync()
  {
    var res = await repo.GetAsync();
    return res;
  }

  public async Task<PaginationDto<LocationDto>> GetPaginationAsync(int Page, int PageSize)
  {
    var res = await repo.GetPaginationAsync(Page, PageSize);
    return res;
  }
}
