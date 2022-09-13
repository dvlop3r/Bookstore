using Bookstore.Client.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Client.Models;

public class BookViewModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    [BindProperty]
    public FileUpload? File { get; set; }

    [FutureDate]
    public DateTime PublishDate { get; set; }
    public DateTime Updated { get; set; }
}