using Bookstore.Contracts.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly IOptions<AppSettings> _options;

        public StorageService(IOptions<AppSettings> options)
        {
            _options = options;
        }

        public Task<string> GetUserProfilePath(Guid Id) => Task.FromResult(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), _options.Value.Storage, Id.ToString()));
    }
}
