using AutoMapper;
using Microsoft.AspNetCore.Http;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class BookFileService : IBookFileService
    {
        private readonly IMapper _mapper;
        private readonly IBookFileRepository _bookFileRepository;

        public BookFileService(IMapper mapper, IBookFileRepository bookPdfRepository)
        {
            _mapper = mapper;
            _bookFileRepository = bookPdfRepository;
        }

        public async Task<bool> CheckIfFileExist(int bookId)
        {
            var file = await _bookFileRepository.GetAsync(x => x.BookId == bookId);

            return file != null;
        }
        public async Task<bool> AddFile(int bookId, IFormFile file)
        {
            var bookFile = new BookFile()
            {
                FileName = file.FileName,
                BookId = bookId
            };

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bookFile.ByteContent = memoryStream.ToArray();
            }

            await _bookFileRepository.AddAsync(bookFile);

            return await _bookFileRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteFile(int bookId)
        {
            var bookFile = (await _bookFileRepository.GetListToEditAsync(x => x.BookId == bookId)).FirstOrDefault() ?? throw new EntityNotFoundException(typeof(BookFile));

            _bookFileRepository.Delete(bookFile);

            return await _bookFileRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateFile(int bookId, IFormFile file)
        {
            var bookFile = (await _bookFileRepository.GetListToEditAsync(x => x.BookId == bookId)).FirstOrDefault() ?? throw new EntityNotFoundException(typeof(BookFile));

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bookFile.ByteContent = memoryStream.ToArray();
            }

            return await _bookFileRepository.SaveChangesAsync();
        }
    }
}
