using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<IdNameDTO>> GetCategoryList()
        {
            var list = await _categoryRepository.GetListAsync();

            var idNameList = list.Select(x => new IdNameDTO() { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();

            return idNameList;
        }
    }
}
