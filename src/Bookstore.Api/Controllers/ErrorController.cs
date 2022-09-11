using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

public class ErrorController : ApiController
{
    [HttpGet]
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception?.GetType().Name == "ValidationException")
            return ValidationProblem(exception);
            
        return Problem(exception);
    }
}