using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<BookDto>>> GetBooks([FromQuery] BookSearchRequest request)
        {
            var result = await _bookService.SearchAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookRequest request)
        {
            var book = await _bookService.CreateAsync(request);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            try
            {
                var book = await _bookService.UpdateAsync(id, request);
                return Ok(book);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
