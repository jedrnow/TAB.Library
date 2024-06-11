using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<IdNameDTO>> GetCategoryList();
    }
}
