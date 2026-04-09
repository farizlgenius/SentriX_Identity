using System;

namespace Identity.Application.DTOs;

public sealed record CreateDepartmentDto(string Name, string Description, int CompanyId);
