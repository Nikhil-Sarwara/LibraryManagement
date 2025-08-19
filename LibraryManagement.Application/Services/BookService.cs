using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;

            return _mapper.Map<BookDto>(book);
        }

        public async Task<PagedResult<BookDto>> SearchAsync(BookSearchRequest request)
        {
            var allBooks = await _bookRepository.GetAllAsync();
            var query = allBooks.AsQueryable();

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(b => b.Title.Contains(request.Title, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.Author))
            {
                query = query.Where(b => b.Authors.Contains(request.Author, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.Genre))
            {
                query = query.Where(b => b.Genres.Contains(request.Genre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.ISBN))
            {
                query = query.Where(b => b.ISBN == request.ISBN);
            }

            if (request.IsAvailable.HasValue)
            {
                query = request.IsAvailable.Value
                    ? query.Where(b => b.AvailableCopies > 0)
                    : query.Where(b => b.AvailableCopies == 0);
            }

            var totalCount = query.Count();

            var books = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var bookDtos = _mapper.Map<List<BookDto>>(books);

            return new PagedResult<BookDto>
            {
                Items = bookDtos,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }

        public async Task<BookDto> CreateAsync(CreateBookRequest request)
        {
            var book = _mapper.Map<Book>(request);
            book.AvailableCopies = book.TotalCopies;

            await _bookRepository.AddAsync(book);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateAsync(int id, UpdateBookRequest request)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new ArgumentException("Book not found");

            _mapper.Map(request, book);
            book.UpdatedAt = DateTime.UtcNow;

            await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookDto>(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new ArgumentException("Book not found");

            await _bookRepository.DeleteAsync(book);
        }
    }
}
