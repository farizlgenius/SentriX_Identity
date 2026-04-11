using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public class CompanyService(ICompanyRepository repo) : ICompanyService
{
      public async Task<CompanyDto> CreateAsync(CreateCompanyDto dto)
      {
            if (string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            if (await repo.IsAnyWithNameAsync(dto.Name))
                  throw new BadRequestException(ResponseMessage.DuplicatedName);


            var domain = new Company(0, dto.Name.Trim(), dto.Address, dto.Description);

            return await repo.AddAsync(domain);


      }

      public async Task<CompanyDto> DeleteByIdAsync(int id)
      {
            if (!await repo.IsAnyWithIdAsync(id))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            return await repo.DeleteByIdAsync(id);
      }

      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int Page, int PageSize)
      {
            return await repo.GetPaginationCompaniesByLocationIdAsync(Page, PageSize);
      }

      public async Task<CompanyDto> UpdateAsync(CompanyDto dto)
      {
            if (!await repo.IsAnyWithIdAsync(dto.Id))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            if (string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            var domain = new Company(dto.Id, dto.Name, dto.Address, dto.Description);

            return await repo.UpdateAsync(domain);
      }
}
