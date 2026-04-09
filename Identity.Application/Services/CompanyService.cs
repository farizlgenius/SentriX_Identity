using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;

namespace Identity.Application.Services;

public class CompanyService(ICompanyRepository repo) : ICompanyService
{
      public async Task<CompanyDto> CreateAsync(CompanyDto dto)
      {
            if (string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            if (!await repo.IsAnyLocationWithIdAsync(dto.LocationId))
                  throw new BadRequestException(ResponseMessage.LocationInvalid);

            var domain = new Company(0, dto.Name.Trim(), dto.Address, dto.Description, dto.LocationId, dto.LocationName);

            return await repo.AddAsync(domain);


      }

      public async Task<CompanyDto> DeleteByIdAsync(int id)
      {
            if (!await repo.IsAnyWithIdAsync(id))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            return await repo.DeleteByIdAsync(id);
      }

      public async Task<PaginationDto<CompanyDto>> GetPaginationCompaniesByLocationIdAsync(int LocationId, int Page, int PageSize)
      {
            if (!await repo.IsAnyLocationWithIdAsync(LocationId))
                  throw new NotFoundException(ResponseMessage.LocationInvalid);

            return await repo.GetPaginationCompaniesByLocationIdAsync(LocationId, Page, PageSize);
      }

      public async Task<CompanyDto> UpdateAsync(CompanyDto dto)
      {
            if (!await repo.IsAnyWithIdAsync(dto.Id ?? 0))
                  throw new BadRequestException(ResponseMessage.RecordNotFound);

            if (string.IsNullOrWhiteSpace(dto.Name))
                  throw new BadRequestException(ResponseMessage.NameEmpty);

            if (!await repo.IsAnyLocationWithIdAsync(dto.LocationId))
                  throw new BadRequestException(ResponseMessage.LocationInvalid);

            var domain = new Company(dto.Id ?? 0, dto.Name, dto.Address, dto.Description, dto.LocationId, dto.LocationName);

            return await repo.UpdateAsync(domain);
      }
}
