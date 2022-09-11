namespace Bookstore.Domain.Enums;

public enum ExceptionType
{
    BadRequest = 400,
    NotFound = 404,
    InternalServerError = 500,
    ValidationException = 422,
    Unauthorized = 401,
    ArgumentNullException = 400,
}