using System;

namespace Identity.Application.DTOs;

public record CompanyDto(string Name,string Description,string Address,int? Id=0);
