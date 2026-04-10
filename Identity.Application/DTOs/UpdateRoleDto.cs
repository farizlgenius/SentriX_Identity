using System;

namespace Identity.Application.DTOs;

public sealed record UpdateRoleDto(int Id, string Name, List<PermissionDto> Permissions, int LocationId);