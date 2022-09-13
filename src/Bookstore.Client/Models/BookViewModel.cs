using Bookstore.Client.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.Models;

public class BookViewModel
{
    public Guid Id { get; set; }
    [Required]
    [TitleLength]
    public string Title { get; set; }
    [StringLength(20, MinimumLength = 10, ErrorMessage = "Title must be between 10 and 20 characters")]
    public string? Description { get; set; }
    public string? Author { get; set; }
    [BindProperty]
    public FileUpload Files { get; set; }

    [FutureDate]
    public DateTime PublishDate { get; set; }
    public DateTime Updated { get; set; }
}