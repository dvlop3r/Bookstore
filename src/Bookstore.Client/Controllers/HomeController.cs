using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Client.Models;
using Bookstore.Client.Services;

namespace Bookstore.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetBooksAsync();
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var book = await _bookService.GetBookAsync(Id);
        return View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookViewModel model)
    {
        if (ModelState.IsValid)
        {
            var book = new BookStoreRequest(
                Title: model.Title,
                Author: model.Author,
                Description: model.Description,
                PublishDate: model.PublishDate,
                CoverImageUrl: "something",
                BookUrl: "something");
            
           var created = await _bookService.CreateBookAsync(book);
            ViewBag.Message = created ? "Book added successfully!" : "Failed to add book!";
        }

        return View(model);
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
