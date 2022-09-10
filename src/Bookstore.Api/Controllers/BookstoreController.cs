using Bookstore.Application.Queries;
using Bookstore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookstoreController : ControllerBase
    {
        private readonly ISender _mapper;

        public BookstoreController(ISender mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _mapper.Send(new GetBooksQuery());
            return Ok(books);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Book>> GetBook(int id)
        // {
        //     var book = await _bookstoreService.GetBookAsync(id);
        //     if (book == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(book);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Book>> CreateBook(Book book)
        // {
        //     var createdBook = await _bookstoreService.CreateBookAsync(book);
        //     return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> UpdateBook(int id, Book book)
        // {
        //     if (id != book.Id)
        //     {
        //         return BadRequest();
        //     }

        //     var updated = await _bookstoreService.UpdateBookAsync(book);
        //     if (!updated)
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteBook(int id)
        // {
        //     var deleted = await _bookstoreService.DeleteBookAsync(id);
        //     if (!deleted)
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }
    }
}