﻿using Bookstore.Client.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bookstore.Client.Controllers
{
    [Authorize]
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
        public string Message(string message) => _message ?? (_message = $"Failed to {message} book!");
    }
}
