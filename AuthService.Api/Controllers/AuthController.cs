using AuthService.Application.DTOs.Password;
using AuthService.Application.Features.Auth.Commands.LoginEmployee;
using AuthService.Application.Features.Auth.Commands.Logout;
using AuthService.Application.Features.Auth.Commands.RefreshAccessToken;
using AuthService.Application.Features.Auth.Commands.RegisterEmployee;
using AuthService.Application.Features.Auth.Commands.ResetPassword;
using AuthService.Application.Features.Auth.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/auth")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register/employee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshAccessTokenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Logged out successfully" });
        }
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _mediator.Send(new ForgotPasswordCommand { Email = request.Email });
            return Ok(new { Message = "If the email is valid, a password reset link will be sent." });
        }
        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _mediator.Send(new ResetPasswordCommand { Token = request.Token, NewPassword = request.NewPassword });
            return Ok(new { Message = "Reset password successfully" });
        }
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var profile = await _mediator.Send(new GetProfileQuery { Id = id });
            return Ok(profile);
        }
    }
}
