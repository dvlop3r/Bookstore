using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using Bookstore.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Bookstore.Application.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
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

        return updated;
    }
}