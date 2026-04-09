using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPaginationCompaniesByLocationIdAsync([FromQuery] int LocationId,int Page,int PageSize)
        {
            var res = await service.GetPaginationCompaniesByLocationIdAsync(LocationId, Page, PageSize);
            return Ok(res);
        }
    }
}
