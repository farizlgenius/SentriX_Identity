using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface IDepartmentService
{
  Task<PaginationDto<DepartmentDto>> GetPaginationByCompanyIdAsync(int CompanyId, int Page, int PageSize, string Search);
  Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
  Task<DepartmentDto> DeleteByIdAsync(int id);
  Task<DepartmentDto> UpdateAsync(DepartmentDto dto);
  Task<List<DepartmentDto>> DeleteRangeAsync(RangeIdDto dto);
  Task<List<DepartmentDto>> GetByCompanyIdAsync(int id);
}
