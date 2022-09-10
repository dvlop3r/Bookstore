using Bookstore.Application.Interfaces;
using Bookstore.Application.Models;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Queries;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookstoreResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BookstoreResult>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.Books.Table.ToListAsync(cancellationToken);
        if(books == null)
            throw new Exception("Books not found");
        return _mapper.Map<IEnumerable<BookstoreResult>>(books);
    }
}