using System;

namespace Identity.Application.DTOs;

public record PasswordRuleDto(int Id,int Len,bool IsLower,bool IsUpper,bool IsSymbol,bool IsDigit,List<string> Weaks);
