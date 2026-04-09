namespace Identity.Application.DTOs;

public sealed record CreateCompanyDto(string Name, string Address, string Description, int LocationId);
