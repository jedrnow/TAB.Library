using AutoMapper;
using TAB.Library.Backend.Core.Models;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Mapping
{
    public class PaginatedListMappingProfile : Profile
    {
        public PaginatedListMappingProfile()
        {
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedListDTO<>)).ConvertUsing(typeof(PaginatedListToDtoConverter<,>));
        }
    }

    public class PaginatedListToDtoConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedListDTO<TDestination>>
    {
        public PaginatedListDTO<TDestination> Convert(PaginatedList<TSource> source, PaginatedListDTO<TDestination> destination, ResolutionContext context)
        {
            var mappedList = context.Mapper.Map<List<TDestination>>(source.ToList());
            return new PaginatedListDTO<TDestination>
            {
                List = mappedList,
                TotalPages = source.TotalPages
            };
        }
    }
}
