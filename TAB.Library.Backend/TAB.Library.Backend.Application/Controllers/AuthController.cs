using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Application.Models;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public AuthController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterInput input)
        {
            var command = new RegisterCommand(input);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var command = new LoginCommand(input);

            var result = await _mediator.Send(command);

            if (result)
            {
                var claimsIdentity = await _userService.GetClaimsIdentity(input.Username);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("IsAuthenticated")]
        [Authorize]
        public IActionResult IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated) return Ok();

            throw new UserUnauthorizedException();
        }

        [HttpGet("IsAdmin")]
        [Authorize]
        public async Task<IActionResult> IsAdmin()
        {
            var username = User.Identity?.Name ?? throw new UserUnauthorizedException();

            var hasAdminPermission = await _userService.CheckAdminPermissions(username);

            if (hasAdminPermission) return Ok();

            throw new UserUnauthorizedException();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
