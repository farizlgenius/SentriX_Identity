using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;

namespace Identity.Application.Services;

public sealed class PositionService(IPositionRepository repo) : IPositionService
{
      public async Task<PositionDto> CreateAsync(CreatePositionDto dto)
      {
            if(string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            if(await repo.IsAnyWithNameAsync(dto.Name))
                  throw new BadRequestException(ResponseMessage.DuplicatedName);
            
            if(!await repo.IsAnyWithDepartmentIdAsync(dto.DepartmentId))
                  throw new BadRequestException(ResponseMessage.DepartmentInvalid);

            var domain = new Domain.Entities.Position(0,dto.Name,dto.Description,dto.DepartmentId);

            return await repo.AddAsync(domain);
      }

      public async Task<PositionDto> DeleteByIdAsync(int id)
      {
            if(!await repo.IsAnyWithIdAsync(id))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            return await repo.DeleteByIdAsync(id);
      }

      public async Task<PaginationDto<PositionDto>> GetPaginationWithDepartmentIdAsync(int DepartmentId, int Page, int PageSize)
      {
            var res = await repo.GetPaginationWithDepartmentIdAsync(DepartmentId, Page, PageSize);
            return res; 
      }

      public async Task<PositionDto> UpdateAsync(PositionDto dto)
      {
            if(string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            if(await repo.IsAnyWithNameAsync(dto.Name))
                  throw new BadRequestException(ResponseMessage.DuplicatedName);
            
            if(!await repo.IsAnyWithDepartmentIdAsync(dto.DepartmentId))
                  throw new BadRequestException(ResponseMessage.DepartmentInvalid);

            if(!await repo.IsAnyWithIdAsync(dto.Id))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            var domain = new Domain.Entities.Position(dto.Id,dto.Name,dto.Description,dto.DepartmentId);
            return  await repo.UpdateAsync(domain);

      }
}
