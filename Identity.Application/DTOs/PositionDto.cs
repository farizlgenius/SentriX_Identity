namespace Identity.Application.DTOs;

public sealed record PositionDto(int Id,string Name,string Description,int DepartmentId,string DepartmentName);