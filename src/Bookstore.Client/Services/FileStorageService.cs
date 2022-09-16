﻿using Bookstore.Client.Models;
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

        public async Task SaveFilesAsync(BookViewModel model, BookStoreResponse response)
        {
            var bookFileName = model.Files.BookFile.FileName;
            var coverFileName = model.Files.CoverImageFile.FileName;
            
            var newBookFileName = $"{"cover"}{Path.GetExtension(bookFileName)}";
            var newCoverFileName = $"{"book"}{Path.GetExtension(coverFileName)}";

            var bookFilePath = Path.Combine(response.BookUrl, newBookFileName);
            var coverFilePath = Path.Combine(response.CoverImageUrl, newCoverFileName);

            if (Directory.Exists(Path.GetDirectoryName(bookFilePath)))
            {
                Directory.Delete(Path.GetDirectoryName(bookFilePath), true);
                Directory.CreateDirectory(Path.GetDirectoryName(bookFilePath));
            }
            else
                Directory.CreateDirectory(Path.GetDirectoryName(bookFilePath));

            using (var fileStream = new FileStream(bookFilePath, FileMode.Create))
            {
                await model.Files.BookFile.CopyToAsync(fileStream);
            }
            using (var fileStream = new FileStream(coverFilePath, FileMode.Create))
            {
                await model.Files.CoverImageFile.CopyToAsync(fileStream);
            }
        }
        public async Task<File> DownloadImage(BookViewModel model)
        {
            var imageBytes = await System.IO.File.ReadAllBytesAsync(model.CoverImageUrl);
            return File(imageBytes,"")
        }
    }
}
