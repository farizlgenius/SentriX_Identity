using Identity.Api.Helpers;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController(ILocationService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await service.GetAsync();
            return Ok(res);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationAsync([FromQuery] int Page, int PageSize)
        {
            var res = await service.GetPaginationAsync(Page, PageSize);
            return Ok();
        }


    }
}
