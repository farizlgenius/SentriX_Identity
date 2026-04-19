using System;
using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Interfaces;

public interface ICompanyRepository
{
      Task<bool> IsAnyWithNameAsync(string Name);
      Task<PaginationDto<CompanyDto>> GetPaginationCompaniesAsync(int Page, int PageSize,string Search);
      Task<CompanyDto> AddAsync(Company domain);
      Task<CompanyDto> DeleteByIdAsync(int id);
      Task<CompanyDto> UpdateAsync(Company domain);
      Task<bool> IsAnyWithIdAsync(int id);
      Task<bool> IsAllExistByIdsAsync(List<int> ids);
      Task<List<CompanyDto>> DeleteRangeAsync(List<int> ids);
      Task<List<CompanyDto>> GetAllAsync();
}
