using AuthService.Application.Features.Roles.Queries.GetAllRoles;
using AuthService.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
