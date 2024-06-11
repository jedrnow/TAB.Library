using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<PaginatedListDTO<UserDTO>>> GetPaginatedList([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var query = new GetPaginatedUserListQuery(username, pageNumber, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
