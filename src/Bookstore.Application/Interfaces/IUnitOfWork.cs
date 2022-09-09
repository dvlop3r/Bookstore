using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookstore.Application.Interfaces;

public interface IUnitOfWork
{
    #region Repositories
    IBookRepository Books { get; }
    #endregion

    #region Helpers
    IExecutionStrategy ExecutionStrategy { get; }
    DatabaseFacade Database { get; }
    #endregion

    #region Methods
    Task<int> CompleteAsync();
    #endregion

}