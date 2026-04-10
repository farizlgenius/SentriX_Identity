using System;

namespace Identity.Application.DTOs;

public sealed record CreateRoleDto(string Name, List<PermissionDto> Permissions, int LocationId);
