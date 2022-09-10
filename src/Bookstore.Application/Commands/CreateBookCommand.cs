using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using MediatR;

namespace Bookstore.Application.Commands;

public record CreateBookCommand(
    BookstoreRequest Request) : IRequest<BookstoreResult>;