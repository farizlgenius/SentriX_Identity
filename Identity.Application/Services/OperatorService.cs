using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public sealed class OperatorService(IOperatorRepository repo) : IOperatorService
{
  public async Task<OperatorDto> CreateAsync(CreateOperatorDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.OperatorId))
      throw new BadRequestException(ResponseMessage.UserIdEmpty);

    if (string.IsNullOrWhiteSpace(dto.Username))
      throw new BadRequestException(ResponseMessage.UsernameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Password))
      throw new BadRequestException(ResponseMessage.PasswordEmpty);

    if (await repo.IsAnyUsernameAsync(dto.Username))
      throw new BadRequestException(ResponseMessage.DuplicatedUsername);

    if (await repo.IsAnyUserIdAsync(dto.OperatorId))
      throw new BadRequestException(ResponseMessage.DuplicatedUserId);

    if (string.IsNullOrWhiteSpace(dto.Firstname))
      throw new BadRequestException(ResponseMessage.FirstnameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Lastname))
      throw new BadRequestException(ResponseMessage.LastnameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Email))
      throw new BadRequestException(ResponseMessage.EmailEmpty);

    if (await repo.IsExceptLocationIdsAsync(dto.LocationId))
      throw new BadRequestException(ResponseMessage.LocationInvalid);

    if (!await repo.IsValidRoleIdAsync(dto.RoleId))
      throw new BadRequestException(ResponseMessage.RoleInvalid);


    var domain = new Operator(
      dto.OperatorId,
      dto.Username,
      PasswordHasher.HashPassword(dto.Password.Trim()),
      dto.title,
      dto.Firstname,
      dto.Middlename,
      dto.Lastname,
      dto.Gender,
      dto.Email,
      dto.Mobile,
      dto.LocationId,
      dto.RoleId
    );

    return await repo.AddAsync(domain);


  }

  public async Task<OperatorDto> DeleteByIdAsync(int id)
  {
    if (!await repo.IsAnyByIdAsync(id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    return await repo.DeleteByIdAsync(id);
  }

  public async Task<PaginationDto<OperatorDto>> GetPaginationWithLocationIdAsync(int location, int Page, int PageSize)
  {
    if (!await repo.IsAnyWithLocationIdAsync(location))
      throw new NotFoundException(ResponseMessage.LocationInvalid);

    var res = await repo.GetPaginationWithLocationIdAsync(location, Page, PageSize);
    return res;
  }

  public async Task<OperatorDto> UpdateAsync(UpdateOperatorDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.OperatorId))
      throw new BadRequestException(ResponseMessage.UserIdEmpty);

    if (string.IsNullOrWhiteSpace(dto.Username))
      throw new BadRequestException(ResponseMessage.UsernameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Firstname))
      throw new BadRequestException(ResponseMessage.FirstnameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Lastname))
      throw new BadRequestException(ResponseMessage.LastnameEmpty);

    if (string.IsNullOrWhiteSpace(dto.Email))
      throw new BadRequestException(ResponseMessage.EmailEmpty);

    if (await repo.IsExceptLocationIdsAsync(dto.LocationId))
      throw new BadRequestException(ResponseMessage.LocationInvalid);

    if (!await repo.IsValidRoleIdAsync(dto.RoleId))
      throw new BadRequestException(ResponseMessage.RoleInvalid);

    var domain = new Operator(
      dto.Id,
      dto.OperatorId,
      dto.Username,
      dto.title,
      dto.Firstname,
      dto.Middlename,
      dto.Lastname,
      dto.Gender,
      dto.Email,
      dto.Mobile,
      dto.LocationId,
      dto.RoleId
    );

    return await repo.UpdateAsync(domain);
  }
}
