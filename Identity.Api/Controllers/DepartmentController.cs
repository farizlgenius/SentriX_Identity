using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService service) : ControllerBase
    {
        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetByCompanyIdAsync(int id)
        {
            var res = await service.GetByCompanyIdAsync(id);
            return Ok(res);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationByCompanyIdAsync([FromQuery] int CompanyId, int Page, int PageSize,string? Search)
        {
            var res = await service.GetPaginationByCompanyIdAsync(CompanyId, Page, PageSize, Search ?? "");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDepartmentDto dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await service.DeleteByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] DepartmentDto dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpPost("delete/range")]
        public async Task<IActionResult> DeleteRangeAsync(RangeIdDto dto)
        {
            var res = await service.DeleteRangeAsync(dto);
            return Ok(res);
        }
    }
}
