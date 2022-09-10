using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using Bookstore.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Commands;

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
        // Ensure book doesn't already exist
        var isExist  = await _unitOfWork.Books.TableNoTracking.AnyAsync(b => b.Title == command.Request.Title, cancellationToken);
        if(isExist)
            throw new DuplicateBookException();

        TypeAdapterConfig<BookstoreRequest,Book>.NewConfig()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Created, src => DateTime.Now)
            .Map(dest => dest.Updated, src => DateTime.Now);
        var book = _mapper.Map<Book>(command.Request);

        // Add book to database
        if(await _unitOfWork.Books.addBookAsync(book) is not Book)
            throw new Exception("Error creating book");

        await _unitOfWork.CompleteAsync();

        var result = _mapper.Map<BookstoreResult>(book);

        return result;
    }
}