using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ICompanyRepository
{
      Task<bool> IsAnyLocationWithIdAsync(int LocationId);
      Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId,int Page,int PageSize);
}
