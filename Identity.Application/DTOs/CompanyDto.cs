using System;

namespace Identity.Application.DTOs;

public record CompanyDto(string Name, string Description, string Address, int LocationId, string LocationName, int? Id = 0);
