using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;
        public BookController(IMediator mediator, IBookService bookService)
        {
            _mediator = mediator;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedListDTO<BookDTO>>> GetPaginatedList([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetPaginatedBookListQuery(pageNumber, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
