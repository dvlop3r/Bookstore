using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Client.Models;
using Bookstore.Client.Services;
using Microsoft.Extensions.Options;
using Bookstore.Client.Settings;
using MapsterMapper;
using Nest;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Client.Controllers;

//[Authorize]
public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly IOptions<AppSettings> _appSettings;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;
    private readonly IElasticClient _elasticClient;

    public HomeController(
        ILogger<HomeController> logger,
        IBookService bookService,
        IOptions<AppSettings> settings,
        IFileStorageService fileStorageService,
        IMapper mapper,
        IElasticClient elasticClient) : base(settings)
    {
        _logger = logger;
        _bookService = bookService;
        _appSettings = settings;
        _fileStorageService = fileStorageService;
        _mapper = mapper;
        _elasticClient = elasticClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string message = "")
    {
        var books = await _bookService.GetAllAsync(BaseUrl);
        ViewBag.Message = message;
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
                CoverImageUrl: model.Files?.CoverImageFile != null ? 
                "cover" + Path.GetExtension(model.Files.CoverImageFile.FileName) : null,
                BookUrl: model.Files?.BookFile != null ?
                "book" + Path.GetExtension(model.Files.BookFile.FileName) : null);


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
                CoverImageUrl: model.Files?.CoverImageFile != null ?
                "cover" + Path.GetExtension(model.Files.CoverImageFile.FileName) : model.CoverImageUrl,
                BookUrl: model.Files?.BookFile != null ?
                "book" + Path.GetExtension(model.Files.BookFile.FileName) : model.BookUrl);

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
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.DeleteAsync(BaseUrl, id);
        ViewBag.Message = "Book deleted successfully!";
        return RedirectToAction("Index", "home" , new { Message = ViewBag.Message });
    }

    [HttpGet]
    public async Task<IActionResult> DownloadCoverImage(Guid id)
    {
        var file = await _fileStorageService.DownloadFileAsync(id, "cover");
        if (file.Item1 == null)
            return RedirectToAction("index");
        //return File(file.Item1, $"image/{file.Item3}", file.Item2);
        return File(file.Item1, "application/octet-stream", file.Item3);
        //return File(binaryData, "text/plain", "hello.txt");
    }
    
    [HttpGet]
    public async Task<IActionResult> DownloadBook(Guid id)
    {
        var file = await _fileStorageService.DownloadFileAsync(id, "book");
        if (file.Item1 == null)
            return RedirectToAction("index");
        //return File(file.Item1, "application/pdf", file.Item2);
        return File(file.Item1, "application/octet-stream", file.Item3);
    }

    [HttpGet]
    public async Task<IActionResult> ElasticFilter(string title, string author, string description)
    {
        var fuzziness = await _elasticClient.MultiSearchAsync(selector: ms => ms
        .Search<BookStoreResponse>(s => s
                .Query(q => q
                    .MultiMatch(mm => mm
                        .Fields(ff => ff
                            .Field(f1 => f1.Title)
                            .Field(f2 => f2.Author)
                            .Field(f3 => f3.Description))
                        .Query($"{title} {author} {description}")
                        .Type(TextQueryType.BestFields)
                        .Operator(Operator.Or)
                        .Fuzziness(Fuzziness.Auto)
                        .PrefixLength(2)
                        .MaxExpansions(10)
                        .MinimumShouldMatch(MinimumShouldMatch.Percentage(50)))))
        .Search<BookStoreResponse>(s => s
        .Query(q => q
                    .MultiMatch(mm => mm
                        .Fields(ff => ff
                            .Field(f1 => f1.Title)
                            .Field(f2 => f2.Author)
                            .Field(f3 => f3.Description))
                        .Query($"{title} {author} {description}")
                        .Type(TextQueryType.BestFields)
                        .Operator(Operator.And)
                        .Fuzziness(Fuzziness.Auto)
                        .PrefixLength(2)
                        .MaxExpansions(10)
                        .MinimumShouldMatch(MinimumShouldMatch.Percentage(50))))));

        var bookss = fuzziness.GetResponses<BookStoreResponse>();
        var or = bookss.First().Documents;
        var and = bookss.Last().Documents;

        var books = _mapper.Map<IEnumerable<BookViewModel>>(or);
        return PartialView("_Books", books);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [Route("/error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
