using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using MediatR;

namespace Bookstore.Application.CommandsQueries.Queries;

public record GetBooksQuery : IRequest<IEnumerable<BookstoreResult>>;