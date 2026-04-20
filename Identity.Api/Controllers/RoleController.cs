using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleService service) : ControllerBase
    {
        [HttpGet("location/{id}")]
        public async Task<IActionResult> GetByLocationIdAsync(int id)
        {
            var res = await service.GetByLocationIdAsync(id);
            return Ok(res);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationWithLocationIdAsync([FromQuery]int LocationId, [FromQuery] int Page, [FromQuery] int PageSize)
        {
            var res = await service.GetPaginationWithLocationIdAsync(LocationId, Page, PageSize);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoleDto dto)
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRoleDto dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpGet("feature")]
        public async Task<IActionResult> GetFeaturesAsync()
        {
            var res = await service.GetFeaturesAsync();
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
