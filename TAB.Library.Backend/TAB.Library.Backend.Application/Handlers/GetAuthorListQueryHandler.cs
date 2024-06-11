using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, List<IdNameDTO>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorListQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<List<IdNameDTO>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            List<IdNameDTO> result = await _authorService.GetAuthorList();

            return result;
        }
    }
}
