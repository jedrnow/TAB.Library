﻿using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookService
    {
        Task<bool> CheckIfBookExists(int bookId);
        Task<int> CreateBook(string title, int publishYear, int authorId, int categoryId, string newCategoryName, string newAuthorFirstName, string newAuthorLastName);
        Task<bool> UpdateBook(int bookId, string title, int publishYear, int authorId, int categoryId, string newCategoryName, string newAuthorFirstName, string newAuthorLastName);
        Task<bool> DeleteBook(int bookId);
        Task<BookDetailedDTO> GetBookById(int bookId, int currentUserId);
        Task<PaginatedListDTO<BookDTO>> GetPaginatedBookList(int pageNumber, int pageSize);
    }
}
