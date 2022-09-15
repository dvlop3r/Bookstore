using Bookstore.Client.Models;
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

        public async Task SaveFileAsync(BookViewModel model)
        {
            var bookFileName = model.Files.BookFile.FileName;
            var coverFileName = model.Files.CoverImageFile.FileName;
            
            var bookFileNameNew = $"{model.Id}{Path.GetExtension(bookFileName)}";
            var coverFileNameNew = $"{model.Id}{Path.GetExtension(coverFileName)}";

            var bookFilePath = Path.Combine(_settings.Value.Storage, bookFileNameNew);
            var coverFilePath = Path.Combine(_settings.Value.Storage, coverFileNameNew);

            using (var fileStream = new FileStream(bookFilePath, FileMode.Create))
            {
                await model.Files.BookFile.CopyToAsync(fileStream);
            }
            using (var fileStream = new FileStream(coverFilePath, FileMode.Create))
            {
                await model.Files.CoverImageFile.CopyToAsync(fileStream);
            }
        }
    }
}
