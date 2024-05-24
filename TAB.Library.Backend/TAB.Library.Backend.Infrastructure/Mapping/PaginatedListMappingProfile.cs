using AutoMapper;
using TAB.Library.Backend.Core.Models;

namespace TAB.Library.Backend.Infrastructure.Mapping
{
    public class PaginatedListMappingProfile : Profile
    {
        public PaginatedListMappingProfile()
        {
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
        }
    }

    public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
    {
        public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
        {
            var mappedList = context.Mapper.Map<List<TDestination>>(source.ToList());
            return new PaginatedList<TDestination>(mappedList, source.TotalCount, source.PageIndex, source.PageSize);
        }
    }
}
