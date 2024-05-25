using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedListDTO<RentalDTO>>> GetPaginatedList([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] bool admin = false)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var query = new GetPaginatedRentalListQuery(username, admin, pageNumber, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("{rentalId}/Return")]
        public async Task<ActionResult<bool>> ReturnBook([FromRoute] int rentalId)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new ReturnBookCommand(rentalId, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
