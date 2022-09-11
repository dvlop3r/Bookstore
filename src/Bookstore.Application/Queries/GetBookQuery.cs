using Bookstore.Application.Models;
using Bookstore.Domain.Entities;
using MediatR;

namespace Bookstore.Application.Queries;

public record GetBookQuery(Guid? Id) : IRequest<BookstoreResult>;
