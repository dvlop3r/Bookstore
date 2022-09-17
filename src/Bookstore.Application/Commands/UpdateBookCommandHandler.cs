using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using Bookstore.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;
using Nest;

namespace Bookstore.Application.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookstoreResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IElasticClient _elasticClient;

    public UpdateBookCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IElasticClient elasticClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _elasticClient = elasticClient;
    }

    public async Task<BookstoreResponse> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        // Ensure command is not null
        if (command.Request == null)
            throw new ArgumentNullException("Book request is null");
        
        // Ensure book exists
        var book = await _unitOfWork.Books.getBookByIdAsync(command.Id);
        if(book is null)
            throw new BookNotFoundException("Book not found");

        TypeAdapterConfig<(BookstoreRequest,Guid),Book>.NewConfig()
            .Map(dest => dest.Id, src => command.Id)
            .Map(dest => dest.Updated, src => DateTime.Now)
            .Map(dest => dest, src => command.Request);
        var bookToUpdate = _mapper.Map<Book>((command.Request, command.Id));

        // Update book
        var updated = await _unitOfWork.Books.UpdateAsync(bookToUpdate, true);
        if (updated is not Book b)
            throw new DatabaseErrorException("Book update failed");

        // Update book in ElasticSearch
        var response = _elasticClient.Update<Book>(command.Id, u => u.Doc(bookToUpdate));
        if (!response.IsValid)
            throw new DatabaseErrorException("Error updating book in ElasticSearch");

        return _mapper.Map<BookstoreResponse>(updated);
    }
}