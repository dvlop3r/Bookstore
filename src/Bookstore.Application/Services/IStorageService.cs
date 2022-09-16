using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Services
{
    public interface IStorageService
    {
        string GetUserProfilePath();
        Task<string> GetBookStoragePath(Guid Id);
    }
}
