﻿using System.Diagnostics;
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

    public HomeController(ILogger<HomeController> logger, IBookService bookService, IOptions<AppSettings> settings) : base(settings)
    {
        _logger = logger;
        _bookService = bookService;
        _appSettings = settings;
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
        ViewBag.Message = Message;
        
        if (ModelState.IsValid)
        {
            var book = new BookStoreRequest(
                Title: model.Title,
                Author: model.Author,
                Description: model.Description,
                PublishDate: model.PublishDate);

            var created = await _bookService.CreateAsync<BookStoreRequest, BookStoreResponse, ProblemJson>(BaseUrl, book);
            ViewBag.Message = "Book added successfully!";
        }

        return View(model);
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
