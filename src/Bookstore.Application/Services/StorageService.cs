using Bookstore.Application.Interfaces;
using Bookstore.Contracts.Settings;
using Microsoft.Extensions.Options;

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
