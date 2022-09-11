using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Domain.Entities;
using MapsterMapper;
using MediatR;
using Nest;

namespace Bookstore.Application.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IElasticClient _elasticClient;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IElasticClient elasticClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _elasticClient = elasticClient;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
        if (book is null)
            throw new BookNotFoundException("Book not found");

        var deleted = await _unitOfWork.Books.DeleteAsync(book);
        var response = await _elasticClient.DeleteAsync<Book>(request.Id);
        return deleted;
    }
}