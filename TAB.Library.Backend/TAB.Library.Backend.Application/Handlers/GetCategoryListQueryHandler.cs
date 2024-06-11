using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<IdNameDTO>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryListQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<IdNameDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            List<IdNameDTO> result = await _categoryService.GetCategoryList();

            return result;
        }
    }
}
