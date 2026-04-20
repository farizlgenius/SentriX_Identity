using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController(ISettingService service) : ControllerBase
    {
        [HttpGet("password/rule")]
        public async Task<IActionResult> GetPassowrdRuleAsync()
        {
            var res = await service.GetPassowrdRuleAsync();
            return Ok(res);
        }

        [HttpPost("password/rule")]
        public async Task<IActionResult> CreatePasswordRuleAsync([FromBody] PasswordRuleDto dto)
        {
            var res = await service.CreatePasswordRuleAsync(dto);
            return Ok(res);
        }
    }
}
