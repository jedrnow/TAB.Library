using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<List<IdNameDTO>> GetAuthorList()
        {
            var list = await _authorRepository.GetListAsync();

            var idNameList = list.OrderBy(x => x.LastName).Select(x => new IdNameDTO() { Id = x.Id, Name = x.FirstName + " " + x.LastName }).ToList();

            return idNameList;
        }
    }
}
