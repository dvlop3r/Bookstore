using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using MediatR;

namespace Bookstore.Application.Commands;

public record BookstoreCommand(
    BookstoreRequest Request) : IRequest<BookstoreResult>;