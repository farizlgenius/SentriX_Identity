using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface ICompanyRepository
{
      Task<bool> IsAnyLocationWithIdAsync(int LocationId);
      Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize);
      Task<CompanyDto> AddAsync(Company domain);
      Task<CompanyDto> DeleteByIdAsync(int id);
      Task<CompanyDto> UpdateAsync(Company domain);
      Task<bool> IsAnyWithIdAsync(int id);
}
