using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ICompanyService
{
      Task<PaginationDto<DTOs.CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize);
      Task<CompanyDto> CreateAsync(CreateCompanyDto dto);
      Task<CompanyDto> DeleteByIdAsync(int id);
      Task<CompanyDto> UpdateAsync(CompanyDto dto);
}
