using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using Bookstore.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace Bookstore.Application.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookstoreResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookstoreResult> Handle(GetBookQuery query, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(query.Id);
        if(book == null)
            throw new Exception("Book not found");
        var result = _mapper.Map<BookstoreResult>(book);
        return result;
    }
}