﻿using MediatR;
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
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
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
            var username = User.Identity.Name ?? throw new EntityNotFoundException(typeof(User));

            var command = new CreateRentalCommand(bookId, username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
