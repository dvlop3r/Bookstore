using Bookstore.Contracts.Models;
using FluentValidation;
using Bookstore.Application.Extensions;

namespace Bookstore.Application.Commands;

public class BookstoreRequestValidator : AbstractValidator<BookstoreRequest>
{
    public BookstoreRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().Length(3, 6).WithMessage("Title must be between 3 and 6 characters");
        RuleFor(x => x.Author)
            .NotEmpty().Length(3, 6).WithMessage("Author must be between 3 and 6 characters");
        RuleFor(x => x.Description)
            .NotEmpty().Length(10, 20).WithMessage("Description must be between 10 and 20 characters");
        RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Book cover image url can not be empty");
        RuleFor(x => x.BookUrl).NotEmpty().WithMessage("Book url can not be empty");;
        RuleFor(x => x.PublishDate)
            .NotEmpty().Must(x => x.StartOfDay() >= DateTime.Now.StartOfDay())
            .WithMessage("Publish date must be greater than now");
    }
}