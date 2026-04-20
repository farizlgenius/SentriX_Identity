using System;
using Identity.Application.DTOs;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;

namespace Identity.Application.Services;

public class SettingService(ISettingRepository repo) : ISettingService
{
      public async Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto)
      {
            if(dto.Len == 0 )
                  throw new BadRequestException(ResponseMessage.PasswordLenEmpty);
            
            var res = await repo.CreatePasswordRuleAsync(dto);
            return res;
      }

      public async Task<PasswordRuleDto> GetPassowrdRuleAsync()
      {
            var res  = await repo.GetPassowrdRuleAsync();
            return res;
      }
}
