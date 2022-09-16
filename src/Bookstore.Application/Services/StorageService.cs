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
        public string GetUserProfilePath() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public Task<string> GetBookStoragePath(Guid Id) => Task.FromResult(Path.Combine(GetUserProfilePath(), _options.Value.Storage ?? "BookstoreStorage", Id.ToString()));

    }
}
