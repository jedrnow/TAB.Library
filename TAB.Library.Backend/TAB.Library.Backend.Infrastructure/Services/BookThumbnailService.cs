using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Jpeg;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Constants;

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

        public async Task<bool> AddThumbnails(int bookId, IFormFile file)
        {
            var thumbnailsList = new List<BookThumbnail>();

            using var image = await Image.LoadAsync(file.OpenReadStream());

            var smallThumbnail = await CreateThumbnail(bookId, image, ThumbnailSize.Small);
            thumbnailsList.Add(smallThumbnail);

            var mediumThumbnail = await CreateThumbnail(bookId, image, ThumbnailSize.Medium);
            thumbnailsList.Add(mediumThumbnail);

            var largeThumbnail = await CreateThumbnail(bookId, image, ThumbnailSize.Large);
            thumbnailsList.Add(largeThumbnail);

            await _bookThumbnailRepository.AddRangeAsync(thumbnailsList);

            return await _bookThumbnailRepository.SaveChangesAsync();
        }

        private async Task<BookThumbnail> CreateThumbnail(int bookId, Image image, ThumbnailSize thumbnailSize)
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
