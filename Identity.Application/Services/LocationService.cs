using System;
using System.Net;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;


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

  public async Task<LocationDto> CreateAsync(CreateLocationDto dto)
  {
    // Name must not be the same
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);
    if (await repo.IsAnyNameAsync(dto.Name))
      throw new BadRequestException(ResponseMessage.DuplicatedName);

    // Check country id is valid
    if (!await repo.IsValidCountryAsync(dto.CountryId))
      throw new BadRequestException(ResponseMessage.CountryInvalid);

    var domain = new Location(0, StringHelper.ToCapital(dto.Name.Trim()), dto.CountryId, dto.Description);

    return await repo.AddAsync(domain);
  }

  public async Task<PaginationDto<CountryDto>> GetCountriesPaginationAsync(int Page, int PageSize)
  {
    var res = await repo.GetCountriesPaginationAsync(Page, PageSize);
    return res;
  }

  public async Task<LocationDto> DeleteByIdAsync(int id)
  {
    if (!await repo.IsAnyByIdAsync(id))
      throw new NotFoundException(ResponseMessage.LocationNotFound);

    return await repo.DeleteByIdAsync(id);
  }

  public async Task<LocationDto> UpdateAsync(LocationDto dto)
  {

    if (!await repo.IsAnyByIdAsync(dto.Id))
      throw new NotFoundException(ResponseMessage.LocationNotFound);

    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    // Check country id is valid
    if (!await repo.IsValidCountryAsync(dto.CountryId))
      throw new BadRequestException(ResponseMessage.CountryInvalid);

    var domain = new Location(dto.Id, StringHelper.ToCapital(dto.Name.Trim()), dto.CountryId, dto.Description);

    return await repo.UpdateAsync(domain);


  }
}
