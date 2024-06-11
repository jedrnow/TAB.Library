using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<IdNameDTO>>> GetAuthorList()
        {
            var query = new GetAuthorListQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
