using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using MediatR;

namespace Bookstore.Application.Commands;
public record UpdateBookCommand(
    Guid Id,
    BookstoreRequest  Request) : IRequest<BookstoreResponse>;
