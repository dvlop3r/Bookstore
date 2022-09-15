using Bookstore.Client.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bookstore.Client.Controllers
{
    public class BaseController : Controller
    {
        private readonly IOptions<AppSettings> _settings;

        public BaseController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        private string? _baseUrl;
        public string? _message;
        public string BaseUrl => _baseUrl ?? (_baseUrl = _settings.Value.Services.ApiUrl);
        public string Message => _message ?? (_message = "Failed to add book!");
    }
}
