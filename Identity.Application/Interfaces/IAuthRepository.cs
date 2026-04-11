using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface IAuthRepository
{
  Task<bool> IsAnyUserExistsAsync(string username);
  Task<string> GetUserHashPasswordAsync(string username);
  Task<UserInTokenDto> GetUserByUsernameAsync(string username);
  Task<List<int>> GetLocationsByUsernameAsync(string username);
  Task<List<PermissionDto>> GetPermissionsByRoleIdAsync(int roleId);
}
