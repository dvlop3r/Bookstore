using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands;

public record DeleteBookCommand(Guid? Id) : IRequest<bool>;