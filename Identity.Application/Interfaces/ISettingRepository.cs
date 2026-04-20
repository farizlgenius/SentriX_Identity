using System;
using Identity.Application.DTOs;

namespace Identity.Application.Interfaces;

public interface ISettingRepository
{
      Task<PasswordRuleDto> GetPassowrdRuleAsync();
      Task<PasswordRuleDto> CreatePasswordRuleAsync(PasswordRuleDto dto);
}
