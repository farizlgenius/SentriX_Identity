using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IDepartmentRepository
{
  Task<bool> IsAnyComanyWithIdAsync(int id);
  Task<bool> IsAnyWithIdAsync(int id);
  Task<bool> IsAnyWithNameAsync(string name);
  Task<DepartmentDto> AddAsync(Department domain);
  Task<DepartmentDto> UpdateAsync(Department domain);
  Task<DepartmentDto> DeleteByIdAsync(int id);
  Task<PaginationDto<DepartmentDto>> GetPaginationByCompanyIdAsync(int companyId, int page, int pageSize, string search);
  Task<bool> IsAllExistByIdsAsync(List<int> ids);
  Task<List<DepartmentDto>> DeleteRangeAsync(List<int> ids);
  Task<List<DepartmentDto>> GetByCompanyIdAsync(int id);
  
}
