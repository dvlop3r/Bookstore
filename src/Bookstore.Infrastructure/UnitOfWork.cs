using Bookstore.Application.Interfaces;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookstore.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    internal AppDbContext _context;
    private IBookRepository? _books;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    #region Repositories
    public IBookRepository Books => _books ??= new BookRepository(_context);
    #endregion

    #region Helpers
    public IExecutionStrategy ExecutionStrategy => _context.Database.CreateExecutionStrategy();
    public DatabaseFacade Database => _context.Database;
    #endregion

    #region Methods
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    #endregion
}