using System;

namespace Identity.Application.DTOs;

public sealed record CreatePositionDto(string Name,string Description,int DepartmentId);