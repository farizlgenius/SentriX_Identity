using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface IPositionRepository
{
      Task<PaginationDto<PositionDto>> GetPaginationWithDepartmentIdAsync(int DepartmentId, int Page, int PageSize,string Search);
      Task<bool> IsAnyWithNameAsync(string Name);
      Task<bool> IsAnyWithDepartmentIdAsync(int DepartmentId);
      Task<PositionDto> AddAsync(Domain.Entities.Position domain);
      Task<bool> IsAnyWithIdAsync(int id);
      Task<PositionDto> DeleteByIdAsync(int id);
      Task<PositionDto> UpdateAsync(Domain.Entities.Position domain);
      Task<bool> IsAllExistByIdsAsync(List<int> ids);
  Task<List<PositionDto>> DeleteRangeAsync(List<int> ids);
}
