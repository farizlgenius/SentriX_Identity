using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IRoleRepository
{
  Task<bool> IsAnyLocationIdAsync(int LocationId);
  Task<bool> IsAnyNameWithLocationIdAsync(int LocationId, string Name);
  Task<PaginationDto<RoleDto>> GetPaginationWithLocationIdAsync(int LocationId, int Page, int PageSize);
  Task<RoleDto> AddAsync(Role domain);
  Task<bool> IsAnyWithIdAsync(int id);
  Task<RoleDto> DeleteByIdAsync(int id);
  Task<RoleDto> UpdateAsync(Role domain);
}
