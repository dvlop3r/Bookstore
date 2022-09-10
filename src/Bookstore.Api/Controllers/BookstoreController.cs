using Bookstore.Application.Commands;
using Bookstore.Application.Queries;
using Bookstore.Contracts.Models;
using Bookstore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookstoreController : ControllerBase
    {
        private readonly ISender _sender;

        public BookstoreController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookstoreResponse>>> GetBooks()
        {
            var books = await _sender.Send(new GetBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookstoreResponse>> GetBook(Guid id)
        {
            if(id == Guid.Empty)
                return BadRequest("Invalid Id");
                
            var result = await _sender.Send(new GetBookQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BookstoreResponse>> CreateBook(BookstoreRequest request)
        {
            if(request is null)
                return BadRequest();

            var result = await _sender.Send(new BookstoreCommand(request));

            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

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