using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Application.Models;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook([FromBody] CreateBookInput input)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new CreateBookCommand(input, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        [Route("{bookId}")]
        public async Task<ActionResult<bool>> UpdateBook([FromRoute] int bookId, [FromBody] UpdateBookInput input)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new UpdateBookCommand(bookId, input, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task<ActionResult<bool>> DeleteBook([FromRoute] int bookId)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new DeleteBookCommand(bookId, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<ActionResult<BookDetailedDTO>> GetBookById([FromRoute] int bookId)
        {
            var query = new GetBookByIdQuery(bookId);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedListDTO<BookDTO>>> GetPaginatedList([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetPaginatedBookListQuery(pageNumber, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("{bookId}/Rent")]
        public async Task<ActionResult<bool>> CreateRental([FromRoute] int bookId)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new CreateRentalCommand(bookId, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("{bookId}/Thumbnail")]
        public async Task<ActionResult<bool>> CreateOrUpdateThumbnail([FromRoute] int bookId, [FromForm] IFormFile file)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new CreateOrUpdateThumbnailCommand(bookId, file, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("{bookId}/File")]
        public async Task<ActionResult<bool>> CreateOrUpdateFile([FromRoute] int bookId, [FromForm] IFormFile file)
        {
            var username = User.Identity?.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new CreateOrUpdateFileCommand(bookId, file, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
