using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ISettingService
{
       Task<PasswordRuleDto> GetPassowrdRuleAsync();
       Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto);
}
