using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Bookstore.Application.CommandsQueries.Commands;

public class BookstoreCommandHandler : IRequestHandler<BookstoreCommand, BookstoreResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookstoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BookstoreResult> Handle(BookstoreCommand command, CancellationToken cancellationToken)
    {
        // Ensure command is not null
        if(command is null)
            throw new ArgumentNullException(nameof(command));

        TypeAdapterConfig<BookstoreCommand,Book>.NewConfig()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Created, src => DateTime.Now)
            .Map(dest => dest.Updated, src => DateTime.Now);
        var book = _mapper.Map<Book>(command.Request);

        if(await _unitOfWork.Books.addBookAsync(book) is not Book)
            throw new Exception("Error creating book");

        TypeAdapterConfig<Book,BookstoreResult>.NewConfig()
            .Map(dest => dest.Id, src => src.Id);
        var result = _mapper.Map<BookstoreResult>(book);

        return result;
    }
}