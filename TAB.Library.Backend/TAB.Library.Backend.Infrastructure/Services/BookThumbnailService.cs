using AutoMapper;
using Microsoft.AspNetCore.Http;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Exceptions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class BookThumbnailService : IBookThumbnailService
    {
        private readonly IMapper _mapper;
        private readonly IBookThumbnailRepository _bookThumbnailRepository;

        public BookThumbnailService(IMapper mapper, IBookThumbnailRepository bookThumbnailRepository)
        {
            _mapper = mapper;
            _bookThumbnailRepository = bookThumbnailRepository;
        }

        public async Task<bool> CheckIfThumbnailsExist(int bookId)
        {
            var thumbnails = await _bookThumbnailRepository.GetListAsync(x => x.BookId == bookId);

            return thumbnails.Any(x => x.Size == ThumbnailSize.Small) && thumbnails.Any(x => x.Size == ThumbnailSize.Medium) && thumbnails.Any(x => x.Size == ThumbnailSize.Large);
        }
        public async Task<bool> AddThumbnails(int bookId, IFormFile file)
        {
            var thumbnailsList = new List<BookThumbnail>();

            using var image = await Image.LoadAsync(file.OpenReadStream());

            var smallThumbnail = await CreateSingleThumbnail(bookId, image, ThumbnailSize.Small);
            thumbnailsList.Add(smallThumbnail);

            var mediumThumbnail = await CreateSingleThumbnail(bookId, image, ThumbnailSize.Medium);
            thumbnailsList.Add(mediumThumbnail);

            var largeThumbnail = await CreateSingleThumbnail(bookId, image, ThumbnailSize.Large);
            thumbnailsList.Add(largeThumbnail);

            await _bookThumbnailRepository.AddRangeAsync(thumbnailsList);

            return await _bookThumbnailRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteThumbnails(int bookId)
        {
            var bookThumbnails = await _bookThumbnailRepository.GetListToEditAsync(x => x.BookId == bookId);

            _bookThumbnailRepository.DeleteRange(bookThumbnails);

            return await _bookThumbnailRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateThumbnails(int bookId, IFormFile file)
        {
            var bookThumbnails = await _bookThumbnailRepository.GetListToEditAsync(x => x.BookId == bookId);

            using var image = await Image.LoadAsync(file.OpenReadStream());

            var smallThumbnail = bookThumbnails.FirstOrDefault(x => x.Size == ThumbnailSize.Small) ?? throw new EntityNotFoundException(typeof(BookThumbnail));
            await UpdateSingleThumbnail(smallThumbnail, image);

            var mediumThumbnail = bookThumbnails.FirstOrDefault(x => x.Size == ThumbnailSize.Medium) ?? throw new EntityNotFoundException(typeof(BookThumbnail));
            await UpdateSingleThumbnail(mediumThumbnail, image);

            var largeThumbnail = bookThumbnails.FirstOrDefault(x => x.Size == ThumbnailSize.Large) ?? throw new EntityNotFoundException(typeof(BookThumbnail));
            await UpdateSingleThumbnail(largeThumbnail, image);

            return await _bookThumbnailRepository.SaveChangesAsync();
        }

        private async Task<BookThumbnail> CreateSingleThumbnail(int bookId, Image image, ThumbnailSize thumbnailSize)
        {
            var size = GetThumbnailSize(thumbnailSize);

            var thumbnail = image.Clone(ctx => ctx.Resize(size, size));

            using var stream = new MemoryStream();

            await thumbnail.SaveAsJpegAsync(stream);

            var bookThumbnail = new BookThumbnail()
            {
                BookId = bookId,
                Size = thumbnailSize,
                ByteContent = stream.ToArray()
            };

            return bookThumbnail;
        }

        private async Task UpdateSingleThumbnail(BookThumbnail bookThumbnail, Image image)
        {
            var size = GetThumbnailSize(bookThumbnail.Size);

            var thumbnail = image.Clone(ctx => ctx.Resize(size, size));

            using var stream = new MemoryStream();

            await thumbnail.SaveAsJpegAsync(stream);

            bookThumbnail.ByteContent = stream.ToArray();
        }

        private static int GetThumbnailSize(ThumbnailSize thumbnailSize)
        {
            return thumbnailSize switch
            {
                ThumbnailSize.Small => 100,
                ThumbnailSize.Medium => 300,
                ThumbnailSize.Large => 600,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
