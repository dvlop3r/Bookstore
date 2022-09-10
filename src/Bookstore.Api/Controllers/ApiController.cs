using Bookstore.Api.Filters;
using Bookstore.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bookstore.Api.Controllers;

[ApiController]
// [Produces("application/json")]
// [Consumes("application/json")]
// [GlobalExceptionFilter] //handled by exception middleware
public class ApiController : ControllerBase
{
    protected IActionResult Problem(Exception? exception)
    {
        var (StatusCode, Message, Errors) = exception switch
        {
            IServiceException serviceException => (
                (int)serviceException.StatusCode,
                exception.Message ?? serviceException.ErrorMessage,
                serviceException.Errors),
            //DuplicateEmailException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            //BadRequestException serviceException => ((int)serviceException.StatusCode, exception.Message == null ? serviceException.ErrorMessage : exception.Message),
            _ => (500, exception?.Message, null) //default
        };

        return Problem(statusCode: StatusCode, title: Message);
    }
    protected IActionResult ValidationProblem(Exception? exception)
    {
        ValidationException? validationException = exception as ValidationException;
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in validationException?.Errors ?? new List<ValidationFailure>())
        {
            modelStateDictionary.AddModelError(error.PropertyName, error.ErrorMessage);
        }
        return ValidationProblem(modelStateDictionary);
    }
}