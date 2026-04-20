using System;
using System.Data.Common;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public sealed class SettingRepository(AppDbContext context) : ISettingRepository
{
      public async Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto)
      {
            var entity = await context.PasswordRules.FirstOrDefaultAsync();
            if(entity == null)
                  throw new Exception(DbExceptionMessage.RecordNotFound);

            entity.Update(dto);
            var data = context.PasswordRules.Update(entity);

            var save = await context.SaveChangesAsync();

            if(data.Entity == null || save <= 0)
                  throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

            return new PasswordRuleDto(data.Entity.id,data.Entity.len,data.Entity.is_lower,data.Entity.is_upper,data.Entity.is_symbol,data.Entity.is_digit,data.Entity.weaks.Select(x => x.pattern).ToList());
      }

      public async Task<PasswordRuleDto> GetPassowrdRuleAsync()
      {
            return await context.PasswordRules.AsNoTracking()
            .Select(x => new PasswordRuleDto(x.id,x.len,x.is_lower,x.is_upper,x.is_symbol,x.is_digit,x.weaks.Select(x => x.pattern).ToList()))
            .FirstOrDefaultAsync() ?? new PasswordRuleDto(0,0,false,false,false,false,new List<string>());
      }
}
