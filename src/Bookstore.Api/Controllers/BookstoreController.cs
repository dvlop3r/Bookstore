using Bookstore.Application.Commands;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Queries;
using Bookstore.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookstoreController : ApiController
    {
        private readonly ISender _sender;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public BookstoreController(ISender sender, IJwtTokenGenerator jwtTokenGenerator)
        {
            _sender = sender;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookstoreResponse>>> GetBooks()
        {
            var books = await _sender.Send(new GetBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<BookstoreResponse>> GetBook(Guid? id)
        {
            // if(id == Guid.Empty)
                // return BadRequest("Invalid Id");
                
            var result = await _sender.Send(new GetBookQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BookstoreResponse>> CreateBook(BookstoreRequest request)
        {
            if(request is null)
                return BadRequest();

            var result = await _sender.Send(new CreateBookCommand(request));

            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        [HttpPut("{id?}")]
        public async Task<ActionResult> UpdateBook(Guid id, BookstoreRequest book)
        {
            if (id == Guid.Empty || book is null)
                throw new ArgumentNullException("Book request is null");

            var updated = await _sender.Send(new UpdateBookCommand(id, book));

            return Ok(updated);
        }

        [HttpDelete("{id?}")]
        public async Task<ActionResult> DeleteBook(Guid? id)
        {
            var deleted = await _sender.Send(new DeleteBookCommand(id));
            if(!deleted)
                return BadRequest("Unable to delete the book");

            return NoContent();
        }

        // This is just for testing purposes to get a token
        // [AllowAnonymous]
        [HttpGet("getToken")]
        public IActionResult generateToken(){
            var token = _jwtTokenGenerator.generateToken();
            return Ok(token);
        }
    }
}