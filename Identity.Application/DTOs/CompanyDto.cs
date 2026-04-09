using System;

namespace Identity.Application.DTOs;

public record CompanyDto(int Id, string Name, string Description, string Address, int LocationId, string LocationName);
