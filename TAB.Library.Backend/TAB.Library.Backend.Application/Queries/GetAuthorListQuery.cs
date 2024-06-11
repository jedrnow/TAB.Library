using FluentValidation;
using MediatR;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Queries
{
    public class GetAuthorListQuery : IRequest<List<IdNameDTO>>
    {

        public GetAuthorListQuery()
        {
        }
    }

    public class GetAuthorListQueryValidator : AbstractValidator<GetAuthorListQuery>
    {
        public GetAuthorListQueryValidator()
        {
        }
    }
}
