﻿using FluentValidation;
using MediatR;
using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Queries
{
    public class GetPaginatedBookListQuery : IRequest<PaginatedListDTO<BookDTO>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public GetPaginatedBookListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetPaginatedBookListQueryValidator : AbstractValidator<GetPaginatedBookListQuery>
    {
        public GetPaginatedBookListQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Page number is required")
                .GreaterThanOrEqualTo(DefaultSettings.MinPageNumber).WithMessage($"Page number must be between {DefaultSettings.MinPageNumber} and {DefaultSettings.MaxPageNumber}")
                .LessThanOrEqualTo(DefaultSettings.MaxPageNumber).WithMessage($"Page number must be between {DefaultSettings.MinPageNumber} and {DefaultSettings.MaxPageNumber}");

            RuleFor(x => x.PageSize)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Page size is required")
                .GreaterThanOrEqualTo(DefaultSettings.MinPageSize).WithMessage($"Page size must be between {DefaultSettings.MinPageSize} and {DefaultSettings.MaxPageSize}")
                .LessThanOrEqualTo(DefaultSettings.MaxPageSize).WithMessage($"Page size must be between {DefaultSettings.MinPageSize} and {DefaultSettings.MaxPageSize}");
        }
    }
}
