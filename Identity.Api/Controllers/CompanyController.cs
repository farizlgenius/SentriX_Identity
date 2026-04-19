using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService service) : ControllerBase
    {
        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationCompaniesAsync([FromQuery] int Page, [FromQuery] int PageSize,[FromQuery] string? Search)
        {
            var res = await service.GetPaginationCompaniesAsync( Page, PageSize, Search ?? "");
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await service.GetAllAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyDto dto)
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
        public async Task<IActionResult> UpdateAsync([FromBody] CompanyDto dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpPost("delete/range")]
        public async Task<IActionResult> DeleteRangeAsync([FromBody]RangeIdDto dto)
        {
            var res = await service.DeleteRangeAsync(dto);
            return Ok(res);
        }

    }
}
