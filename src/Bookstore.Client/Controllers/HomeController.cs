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

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetBooksAsync();
        return View(books);
    }


    public async Task<IActionResult> Create(BookViewModel model)
    {
        var result = await _bookService.CreateBookAsync(model);
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
