using System.Net;
using Bookstore.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bookstore.Api.Filters;

public class GlobalExceptionFilter : IExceptionFilter //ExceptionFilterAttribute
{
    //private readonly ILogger _logger;

    public void OnException(ExceptionContext context)
    {
        //_logger.Log(LogLevel.Error, context.Exception, context.Exception.Message);

        var exceptionType = context.Exception.GetType();
        var exception = context.Exception;

        if(exceptionType == typeof(ArgumentNullException))
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Bad Request",
                Detail = exception.Message
            };
            context.Result = new BadRequestObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if(exceptionType == typeof(BadRequestException))
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Bad Request",
                Detail = exception.Message
            };
            context.Result = new BadRequestObjectResult(exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if(exceptionType == typeof(NotFoundException))
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Title = "Not Found",
                Detail = exception.Message
            };
            context.Result = new NotFoundObjectResult(exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else if(exceptionType == typeof(DuplicateBookException))
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Title = "Sample Exception",
                Detail = exception.Message
            };
            context.Result = new ObjectResult(exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        else
        {
            context.Result = new ObjectResult(exception.Message)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        context.ExceptionHandled = true;
    }
}