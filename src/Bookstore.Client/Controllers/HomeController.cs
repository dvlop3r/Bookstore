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
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookViewModel model)
    {
        if (ModelState.IsValid)
            await _bookService.CreateBookAsync(model);

        return View(model);
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
