using FluentValidation;
using MediatR;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Queries
{
    public class GetCategoryListQuery : IRequest<List<IdNameDTO>>
    {

        public GetCategoryListQuery()
        {
        }
    }

    public class GetCategoryListQueryValidator : AbstractValidator<GetCategoryListQuery>
    {
        public GetCategoryListQueryValidator()
        {
        }
    }
}
