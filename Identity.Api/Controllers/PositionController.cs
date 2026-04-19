using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController(IPositionService service) : ControllerBase
    {
        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationWithDepartmentIdAsync([FromQuery]int DepartmentId,int Page,int PageSize,string? Search)
        {
            var res = await service.GetPaginationWithDepartmentIdAsync(DepartmentId, Page, PageSize, Search ?? "");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePositionDto dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

         [HttpPut]
         public async Task<IActionResult> UpdateAsync([FromBody] PositionDto dto)
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

        [HttpPost("delete/range")]
        public async Task<IActionResult> DeleteRangeAsync([FromBody] RangeIdDto Ids)
        {
            var res = await service.DeleteRangeAsync(Ids);
            return Ok(res);
        }
    }
}

