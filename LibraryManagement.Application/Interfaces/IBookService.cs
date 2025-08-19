using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.LibraryManagement.Application.DTOs;

namespace LibraryManagement.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto?> GetByIdAsync(int id);
        Task<PagedResult<BookDto>> SearchAsync(BookSearchRequest request);
        Task<BookDto> CreateAsync(CreateBookRequest request);
        Task<BookDto> UpdateAsync(int id, UpdateBookRequest request);
        Task DeleteAsync(int id);
    }
}
