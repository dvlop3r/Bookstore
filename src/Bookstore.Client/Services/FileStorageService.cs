using Bookstore.Client.Settings;
using Microsoft.Extensions.Options;

namespace Bookstore.Client.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IOptions<AppSettings> _settings;

        public FileStorageService(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public async Task<string> SaveFileAsync(string fileName, Stream fileStream)
        {
            var filePath = Path.Combine(_storagePath, fileName);
            using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.CopyToAsync(file);
            }

            return Path.Combine(_storageUrl, fileName);
        }
    }
}
