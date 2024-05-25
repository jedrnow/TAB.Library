using AutoMapper;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => src.PublishYear))
               .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
               .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : string.Empty))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
               .ForMember(dest => dest.PdfContent, opt => opt.MapFrom(src => string.Empty)) // todo
               .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.RentalHistory.Where(x => !x.IsReturned).Any()));
        }
    }
}
