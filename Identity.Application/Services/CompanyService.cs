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

      public async Task<List<CompanyDto>> DeleteRangeAsync(RangeIdDto dto)
      {
            if(dto.Ids == null || dto.Ids.Count <= 0)
                  throw new BadRequestException(ResponseMessage.CompanyInvalid);

            if(!await repo.IsAllExistByIdsAsync(dto.Ids))
                  throw new BadRequestException(ResponseMessage.CompanyNotFound);

            
            return await repo.DeleteRangeAsync(dto.Ids);
      }

      public async Task<List<CompanyDto>> GetAllAsync()
      {
            return await repo.GetAllAsync();
      }

      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesAsync(int Page, int PageSize, string Search)
      {
            return await repo.GetPaginationCompaniesAsync(Page, PageSize, Search);
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
