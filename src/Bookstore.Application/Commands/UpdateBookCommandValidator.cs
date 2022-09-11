using FluentValidation;

namespace Bookstore.Application.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Request).SetValidator(new BookstoreRequestValidator());
    }
}