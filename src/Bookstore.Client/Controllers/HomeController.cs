using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Client.Models;
using Bookstore.Client.Services;
using Microsoft.Extensions.Options;
using Bookstore.Client.Settings;

namespace Bookstore.Client.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly IOptions<AppSettings> _appSettings;
    private readonly IFileStorageService _fileStorageService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService, IOptions<AppSettings> settings, IFileStorageService fileStorageService) : base(settings)
    {
        _logger = logger;
        _bookService = bookService;
        _appSettings = settings;
        _fileStorageService = fileStorageService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetAllAsync(BaseUrl);
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var book = await _bookService.GetAsync(Id, BaseUrl);
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
        ViewBag.Message = Message("create");
        
        if (ModelState.IsValid)
        {
            var book = new BookStoreRequest(
                Title: model.Title,
                Author: model.Author,
                Description: model.Description,
                PublishDate: model.PublishDate,
                null,
                null);

            var result = await _bookService.CreateAsync<BookStoreRequest, BookStoreResponse, ProblemJson>(BaseUrl, book);
            if (result.Item1 != null)
            {
                if(model.Files != null)
                    await _fileStorageService.SaveFilesAsync(model, result.Item1);
                ViewBag.Message = "Book created successfully!";
            }
            else
                ViewBag.Errors = result.Item2;
        }

        return View(model);
    }
    
    [HttpGet]
    [Route("update")]
    public async Task<IActionResult> Update(string id)
    {
        var book = await _bookService.GetAsync(Guid.Parse(id), BaseUrl);
        return View(book);
    }

    [HttpPost]
    [Route("PostUpdate")]
    public async Task<IActionResult> PostUpdate(BookViewModel model)
    {
        ViewBag.Message = Message("update");
        
        if (ModelState.IsValid)
        {
            var book = new BookStoreRequest(
                Title: model.Title,
                Author: model.Author,
                Description: model.Description,
                PublishDate: model.PublishDate,
                CoverImageUrl: model.CoverImageUrl,
                BookUrl: model.BookUrl);

            var result = await _bookService.UpdateAsync<BookStoreRequest, BookStoreResponse, ProblemJson>(BaseUrl, book, model.Id);
            if (result.Item1 != null)
            {
                if (model.Files != null)
                    await _fileStorageService.SaveFilesAsync(model, result.Item1);
                ViewBag.Message = "Book updated successfully!";
            }
            else
                ViewBag.Errors = result.Item2;
        }
        return View("update", model);
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
