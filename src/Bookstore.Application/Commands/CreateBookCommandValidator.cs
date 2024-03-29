using Bookstore.Application.Extensions;
using FluentValidation;

namespace Bookstore.Application.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Request).SetValidator(new BookstoreRequestValidator());
    }
}