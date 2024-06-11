﻿using AutoMapper;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<bool> CheckIfBookExists(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);

            return book != null;
        }

        public async Task<int> CreateBook(string title, int publishYear, int authorId, int categoryId)
        {
            var book = new Book()
            {
                Title = title,
                AuthorId = authorId,
                CategoryId = categoryId,
                PublishYear = publishYear,
            };

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> UpdateBook(int bookId, string title, int publishYear, int authorId, int categoryId)
        {
            var book = await _bookRepository.GetToEditAsync(bookId) ?? throw new EntityNotFoundException(typeof(Book), bookId);

            book.Title = title;
            book.PublishYear = publishYear;
            book.AuthorId = authorId;
            book.CategoryId = categoryId;

            return await _bookRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var book = await _bookRepository.GetToEditAsync(bookId) ?? throw new EntityNotFoundException(typeof(Book), bookId);

             _bookRepository.Delete(book);

            return await _bookRepository.SaveChangesAsync();
        }

        public async Task<BookDTO> GetBookById(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId, x => x.RentalHistory, x => x.Author, x => x.Category, x => x.BookFile, x => x.BookThumbnails) ?? throw new EntityNotFoundException(typeof(Book), bookId);

            var mappedBook = _mapper.Map<BookDTO>(book);

            return mappedBook;
        }

        public async Task<PaginatedListDTO<BookDTO>> GetPaginatedBookList(int pageNumber, int pageSize)
        {
            var bookList = await _bookRepository.GetPaginatedListAsync(pageNumber, pageSize, x => x.RentalHistory, x => x.Author, x => x.Category, x => x.BookFile, x => x.BookThumbnails);

            var mappedBookList = _mapper.Map<PaginatedListDTO<BookDTO>>(bookList);

            return mappedBookList;
        }
    }
}
