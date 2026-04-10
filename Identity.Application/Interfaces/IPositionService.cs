using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IPositionService
{
      Task<PaginationDto<PositionDto>> GetPaginationWithDepartmentIdAsync(int DepartmentId, int Page, int PageSize);
      Task<PositionDto> CreateAsync(CreatePositionDto dto);
      Task<PositionDto> UpdateAsync(PositionDto dto);
      Task<PositionDto> DeleteByIdAsync(int id);
}
