using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;

namespace Identity.Application.Services;

public class CompanyService(ICompanyRepository repo) : ICompanyService
{
      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize)
      {
            if(!await repo.IsAnyLocationWithIdAsync(LocationId))
                  throw new NotFoundException(CompanyResponseMessage.LocationInvalid);

            return await repo.GetPaginationCompaniesByLocationIdAsync(LocationId, Page, PageSize);
      }
}
