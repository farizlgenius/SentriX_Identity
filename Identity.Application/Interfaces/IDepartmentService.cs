using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface IDepartmentService
{
  Task<PaginationDto<DepartmentDto>> GetPaginationByCompanyIdAsync(int CompanyId, int Page, int PageSize);
  Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
  Task<DepartmentDto> DeleteByIdAsync(int id);
  Task<DepartmentDto> UpdateAsync(DepartmentDto dto);
}
