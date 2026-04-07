using System.Security.Claims;
using Identity.Api.Helpers;
using Identity.Application.DTOs;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var token = await service.LoginAsync(dto, Response);
            return ControllerHelper.FromStatusCode(this, token);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Refresh))
            {
                string? refreshToken;
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
                var result = await service.RefreshTokenAsync(refreshToken ?? "", Response);
                return ControllerHelper.FromStatusCode(this, result);
            }
            else
            {
                var result = await service.RefreshTokenAsync(dto.Refresh, Response);
                return ControllerHelper.FromStatusCode(this, result);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Refresh))
            {
                string? refreshToken;
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
                var result = await service.LogoutAsync(refreshToken ?? "", Response);
                return ControllerHelper.FromStatusCode(this, result);
            }
            else
            {
                var result = await service.LogoutAsync(dto.Refresh, Response);
                return ControllerHelper.FromStatusCode(this, result);
            }
        }

        [HttpPost("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var role_id = User.FindFirst("role_id")?.Value ?? "";

            var result = await service.GetMeByUsernameAndRoleIdAsync(username, int.Parse(role_id));
            return ControllerHelper.FromStatusCode(this, result);

        }

        [HttpPost("hash")]
        public async Task<IActionResult> GetHash([FromBody] string password)
        {
            var res = PasswordHasher.HashPassword(password);
            return Ok(res);
        }
    }
}
