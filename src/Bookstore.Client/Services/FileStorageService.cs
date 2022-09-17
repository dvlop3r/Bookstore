using Bookstore.Client.Models;
using Bookstore.Client.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

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

            if (model.Files.BookFile != null)
            {
                using (var fileStream = new FileStream(bookFilePath, FileMode.Create))
                {
                    await model.Files.BookFile.CopyToAsync(fileStream);
                }
            }
            if (model.Files.CoverImageFile != null)
            {
                using (var fileStream = File.Create(coverFilePath))
                {
                    await model.Files.CoverImageFile.CopyToAsync(fileStream);
                }
            }
        }
        public async Task<(byte[], string, string)> DownloadFileAsync(Guid id, string file)
        {
            var filesDir = await GetBookStoragePath(id);
            var files = Directory.GetFiles(filesDir);
            var first = files.Where(x => Path.GetFileName(x).StartsWith(file)).FirstOrDefault();
            if (first is null)
                return (null, null, null);
            byte[] bytes = File.ReadAllBytes(first);
            //byte[] bytes = Encoding.UTF8.GetBytes(filePath);
            var fileName = Path.GetFileName(first);
            var extension = Path.GetExtension(first);
            return (bytes, extension, fileName);
        }
        public string GetUserProfilePath() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public Task<string> GetBookStoragePath(Guid Id) => Task.FromResult(Path.Combine(GetUserProfilePath(), _settings.Value.Storage ?? "BookstoreStorage", Id.ToString()));

    }
}
