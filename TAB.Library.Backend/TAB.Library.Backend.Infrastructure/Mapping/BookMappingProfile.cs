using AutoMapper;
using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDetailedDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => src.PublishYear))
               .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
               .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : string.Empty))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
               .ForMember(dest => dest.PdfContent, opt => opt.MapFrom(src => MapBookFile(src)))
               .ForMember(dest => dest.ThumbnailSmallContent, opt => opt.MapFrom(src => MapThumbnail(src, ThumbnailSize.Small)))
               .ForMember(dest => dest.ThumbnailMediumContent, opt => opt.MapFrom(src => MapThumbnail(src, ThumbnailSize.Medium)))
               .ForMember(dest => dest.ThumbnailLargeContent, opt => opt.MapFrom(src => MapThumbnail(src, ThumbnailSize.Large)))
               .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.RentalHistory.Where(x => !x.IsReturned).Any()))
               .ForMember(dest => dest.ReservedByCurrentUser, opt => opt.MapFrom(src => false));

            CreateMap<Book, BookDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => src.PublishYear))
               .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
               .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : string.Empty))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
               .ForMember(dest => dest.PdfContent, opt => opt.MapFrom(src => MapBookFile(src)))
               .ForMember(dest => dest.ThumbnailMediumContent, opt => opt.MapFrom(src => MapThumbnail(src, ThumbnailSize.Medium)))
               .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.RentalHistory.Where(x => !x.IsReturned).Any()));
        }

        private static string MapThumbnail(Book book, ThumbnailSize size)
        {
            var thumbnail = book.BookThumbnails.FirstOrDefault(x => x.Size == size);

            return thumbnail != null && thumbnail.ByteContent != null
                ? Convert.ToBase64String(thumbnail.ByteContent)
                : string.Empty;
        }

        private static string MapBookFile(Book book)
        {
            var bookFile = book.BookFile;

            return bookFile != null && bookFile.ByteContent != null
                ? Convert.ToBase64String(bookFile.ByteContent)
                : string.Empty;
        }
    }
}
