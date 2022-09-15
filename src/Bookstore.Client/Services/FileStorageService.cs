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

        public async Task SaveFilesAsync(BookViewModel model)
        {
            var bookFileName = model.Files.BookFile.FileName;
            var coverFileName = model.Files.CoverImageFile.FileName;
            
            var newBookFileName = $"{"cover"}{Path.GetExtension(bookFileName)}";
            var newCoverFileName = $"{"book"}{Path.GetExtension(coverFileName)}";

            var bookFilePath = Path.Combine(_settings.Value.Storage, model.Id.ToString(), newBookFileName);
            var coverFilePath = Path.Combine(_settings.Value.Storage, model.Id.ToString(), newCoverFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(bookFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(coverFilePath));

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
