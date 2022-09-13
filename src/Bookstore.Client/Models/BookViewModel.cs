using Bookstore.Client.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.Models;

public class BookViewModel
{
    public Guid Id { get; set; }
    [Range(3, 6, ErrorMessage = "Title must be between 3 and 6 characters")]
    public string? Title { get; set; }
    [Range(10, 20, ErrorMessage = "Description must be between 10 and 20 characters")]
    public string? Description { get; set; }
    public string? Author { get; set; }
    [BindProperty]
    public FileUpload? Files { get; set; }

    [FutureDate]
    public DateTime PublishDate { get; set; }
    public DateTime Updated { get; set; }
}