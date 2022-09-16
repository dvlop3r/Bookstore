using Bookstore.Client.Models;
using Bookstore.Client.Settings;
using Microsoft.AspNetCore.Mvc;
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

        public async Task SaveFilesAsync(BookViewModel model, BookStoreResponse response)
        {
            var bookFilePath = response.BookUrl;
            var coverFilePath = response.CoverImageUrl;

            if (Directory.Exists(Path.GetDirectoryName(bookFilePath)))
            {
                Directory.Delete(Path.GetDirectoryName(bookFilePath), true);
                Directory.CreateDirectory(Path.GetDirectoryName(bookFilePath));
            }
            else
                Directory.CreateDirectory(Path.GetDirectoryName(bookFilePath));

            using (var fileStream = new FileStream(bookFilePath, FileMode.Create))
            {
                if (bookFilePath != null)
                    await model.Files.BookFile.CopyToAsync(fileStream);
            }
            using (var fileStream = File.Create(coverFilePath))
            {
                if (coverFilePath != null)
                    await model.Files.CoverImageFile.CopyToAsync(fileStream);
            }
        }
        public async Task<(byte[],string,string)> DownloadFileAsync(Guid id, string path)
        {
            await Task.CompletedTask;
            var filePath = Path.Combine(path, id.ToString(), path);
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);
            var extension = Path.GetExtension(filePath);
            return (bytes, fileName, extension);
        }
    }
}
