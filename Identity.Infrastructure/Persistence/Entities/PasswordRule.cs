using System;
using System.ComponentModel.DataAnnotations;
using Identity.Application.DTOs;

namespace Identity.Infrastructure.Persistence.Entities;

public sealed class PasswordRule
{
      [Key]
      public int id {get; set;}
      public int len {get;set;}
      public bool is_digit {get; set;}
      public bool is_lower {get; set;}
      public bool is_symbol {get; set;}
      public bool is_upper {get; set;}
      public ICollection<WeakPassword> weaks {get; set;} = new List<WeakPassword>();
      public PasswordRule(){}
      public void Update(PasswordRuleDto dto)
      {
            len = dto.Len;
            is_digit = dto.IsDigit;
            is_lower = dto.IsLower;
            is_symbol = dto.IsSymbol;
            is_upper = dto.IsUpper;
            List<string> Old = weaks.Select(x => x.pattern).ToList();
            List<string> Pattern = dto.Weaks.Where(x => Old.Contains(x)).ToList();
            weaks = Pattern.Select(x => new WeakPassword
            {
                  pattern = x
            }).ToList();
      }

}


