using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public sealed class DepartmentService(IDepartmentRepository repo) : IDepartmentService
{
  public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (await repo.IsAnyWithNameAsync(dto.Name))
      throw new BadRequestException(ResponseMessage.DuplicatedName);

    if(!await repo.IsAnyComanyWithIdAsync(dto.CompanyId))
      throw new BadRequestException(ResponseMessage.CompanyInvalid);

    var domain = new Department(0, dto.Name, dto.Description, dto.CompanyId);

    return await repo.AddAsync(domain);


  }

  public async Task<DepartmentDto> DeleteByIdAsync(int id)
  {
    if (!await repo.IsAnyWithIdAsync(id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    return await repo.DeleteByIdAsync(id);
  }

      public async Task<List<DepartmentDto>> DeleteRangeAsync(RangeIdDto dto)
      {
            if(dto.Ids == null || dto.Ids.Count <= 0)
                  throw new BadRequestException(ResponseMessage.DepartmentInvalid);

            if(!await repo.IsAllExistByIdsAsync(dto.Ids))
                  throw new BadRequestException(ResponseMessage.CompanyNotFound);

            
            return await repo.DeleteRangeAsync(dto.Ids);
      }

      public async Task<List<DepartmentDto>> GetByCompanyIdAsync(int id)
      {
          var res = await repo.GetByCompanyIdAsync(id);
          return res;
      }

      public async Task<PaginationDto<DepartmentDto>> GetPaginationByCompanyIdAsync(int CompanyId, int Page, int PageSize, string Search)
  {
    if (!await repo.IsAnyComanyWithIdAsync(CompanyId))
      throw new BadRequestException(ResponseMessage.QueryIdInvalid);

    var res = await repo.GetPaginationByCompanyIdAsync(CompanyId, Page, PageSize, Search);
    return res;
  }

  public async Task<DepartmentDto> UpdateAsync(DepartmentDto dto)
  {
    if (!await repo.IsAnyWithIdAsync(dto.Id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    var domain = new Department(dto.Id, dto.Name, dto.Description, dto.CompanyId);
    return await repo.UpdateAsync(domain);
  }
}
