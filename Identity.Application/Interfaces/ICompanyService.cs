using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ICompanyService
{
      Task<PaginationDto<DTOs.CompanyDto>> GetPaginationCompaniesAsync(int Page, int PageSize, string Search);
      Task<CompanyDto> CreateAsync(CreateCompanyDto dto);
      Task<CompanyDto> DeleteByIdAsync(int id);
      Task<CompanyDto> UpdateAsync(CompanyDto dto);
      Task<List<CompanyDto>> DeleteRangeAsync(RangeIdDto dto);
      Task<List<CompanyDto>> GetAllAsync();
}
