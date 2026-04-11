using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController(IOperatorService service) : ControllerBase
    {
        [HttpGet("/api/{location}/[controller]/pagination")]
        public async Task<IActionResult> GetPaginationWithLocationIdAsync(int location, [FromQuery] int Page, [FromQuery] int PageSize)
        {
            var res = await service.GetPaginationWithLocationIdAsync(location, Page, PageSize);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOperatorDto dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOperatorDto dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await service.DeleteByIdAsync(id);
            return Ok(res);
        }
    }
}
