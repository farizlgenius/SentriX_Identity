using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IOperatorRepository
{
  Task<PaginationDto<OperatorDto>> GetPaginationWithLocationIdAsync(int LocationId, int Page, int PageSize);
  Task<bool> IsAnyWithLocationIdAsync(int LocationId);
  Task<bool> IsAnyUsernameAsync(string Username);
  Task<bool> IsAnyUserIdAsync(string UserId);
  Task<OperatorDto> AddAsync(Operator domain);
  Task<OperatorDto> UpdateAsync(Operator domain);
  Task<bool> IsAnyByIdAsync(int id);
  Task<OperatorDto> DeleteByIdAsync(int id);
  Task<bool> IsValidCompanyAsync(int CompanyId);
  Task<bool> IsValidDepartmentAsync(int DepartmentId);
  Task<bool> IsValidPositionAsync(int PositionId);
  Task<bool> IsExceptLocationIdsAsync(List<int> LocationIds);
  Task<bool> IsValidRoleIdAsync(int RoleId);
}
