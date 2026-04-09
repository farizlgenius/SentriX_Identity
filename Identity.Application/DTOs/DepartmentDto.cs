using System;

namespace Identity.Application.DTOs;

public sealed record DepartmentDto(int Id, string Name, string Description, int CompanyId, string CompanyName);
