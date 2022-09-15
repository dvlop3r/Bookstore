using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Contracts.Models;
using Bookstore.Contracts.Settings;
using Bookstore.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nest;

namespace Bookstore.Application.Commands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookstoreResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IElasticClient _elasticClient;
    private readonly IOptions<AppSettings> _options;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IElasticClient elasticClient, IOptions<AppSettings> options)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _elasticClient = elasticClient;
        _options = options;
    }
    public async Task<BookstoreResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        // Ensure command is not null
        if (command.Request == null)
            throw new ArgumentNullException("Book request is null");

        // Ensure book doesn't exist already
        var isExist  = await _unitOfWork.Books.TableNoTracking.AnyAsync(b => b.Title == command.Request.Title, cancellationToken);
        if(isExist)
            throw new DuplicateBookException("Book already exists");

        TypeAdapterConfig<BookstoreRequest,Book>.NewConfig()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Created, src => DateTime.Now)
            .Map(dest => dest.Updated, src => DateTime.Now);
        var book = _mapper.Map<Book>(command.Request);
        
        var path = System.Environment.GetEnvironmentVariable("USERPROFILE");
        var filePath = Path.Combine(path, _options.Value.Storage, book.Id.ToString());

        // Add book to database
        if (await _unitOfWork.Books.addBookAsync(book) is not Book)
            throw new DatabaseErrorException("Error adding book to database");

        await _unitOfWork.CompleteAsync();

        // Add book to elasticsearch
        var response = await _elasticClient.IndexDocumentAsync(book);
        if (!response.IsValid)
            throw new DatabaseErrorException("Error adding book to elasticsearch");

        var result = _mapper.Map<BookstoreResult>(book);

        return result;
    }
}