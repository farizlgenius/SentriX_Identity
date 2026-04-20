using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public sealed class RoleService(IRoleRepository repo) : IRoleService
{
  public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (!await repo.IsAnyLocationIdAsync(dto.LocationId))
      throw new BadRequestException(ResponseMessage.LocationInvalid);

    if (await repo.IsAnyNameWithLocationIdAsync(dto.LocationId, dto.Name))
      throw new BadRequestException(ResponseMessage.DuplicatedName);

    var domain = new Role(0, dto.Name, dto.Permissions.Select(r => new Permission(
      r.FeatureId,
      r.FeatureName,
      r.IsEnabled,
      r.IsCreated,
      r.IsUpdated,
      r.IsDeleted
    )).ToList(), dto.LocationId);

    return await repo.AddAsync(domain);

  }

  public async Task<RoleDto> DeleteByIdAsync(int id)
  {
    if (!await repo.IsAnyWithIdAsync(id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    return await repo.DeleteByIdAsync(id);
  }

      public async Task<List<RoleDto>> DeleteRangeAsync(RangeIdDto dto)
      {
            if(dto.Ids == null || dto.Ids.Count <= 0)
                  throw new BadRequestException(ResponseMessage.RoleInvalid);

            if(!await repo.IsAllExistByIdsAsync(dto.Ids))
                  throw new BadRequestException(ResponseMessage.RoleNotFound);

            
            return await repo.DeleteRangeAsync(dto.Ids);
      }

      public async Task<List<RoleDto>> GetByLocationIdAsync(int location)
      {
            var res = await repo.GetByLocationIdAsync(location);
            return res;

      }

      public async Task<List<FeatureDto>> GetFeaturesAsync()
      {
            var res = await repo.GetFeaturesAsync();
            return res;
      }

      public async Task<PaginationDto<RoleDto>> GetPaginationWithLocationIdAsync(int location, int Page, int PageSize)
  {
    if (!await repo.IsAnyLocationIdAsync(location))
      throw new BadRequestException(ResponseMessage.LocationInvalid);

    var res = await repo.GetPaginationWithLocationIdAsync(location, Page, PageSize);
    return res;
  }

  public async Task<RoleDto> UpdateAsync(UpdateRoleDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (!await repo.IsAnyLocationIdAsync(dto.LocationId))
      throw new BadRequestException(ResponseMessage.LocationInvalid);

    var domain = new Role(dto.Id, dto.Name, dto.Permissions.Select(r =>
      new Permission(r.FeatureId, r.FeatureName, r.IsEnabled, r.IsCreated, r.IsUpdated, r.IsDeleted)
    ).ToList(), dto.LocationId);

    var res = await repo.UpdateAsync(domain);
    return res;

  }
}
