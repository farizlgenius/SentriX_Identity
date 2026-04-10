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
