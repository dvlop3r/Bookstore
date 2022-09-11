using FluentValidation;

namespace Bookstore.Application.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Request.Title)
            .NotEmpty().Length(3, 5).WithMessage("Title must be between 3 and 5 characters");
        RuleFor(x => x.Request.Author)
            .NotEmpty().Length(3, 5).WithMessage("Author must be between 3 and 5 characters");
        RuleFor(x => x.Request.Description)
            .NotEmpty().Length(10, 20).WithMessage("Description must be between 10 and 20 characters");
        RuleFor(x => x.Request.CoverImageUrl).NotEmpty().WithMessage("Book cover image url can not be empty");
        RuleFor(x => x.Request.BookUrl).NotEmpty().WithMessage("Book url can not be empty");;
        RuleFor(x => x.Request.PublishDate)
            .NotEmpty().Must(x => x >= DateTime.Now.Date).WithMessage("Publish date must be greater than now");
    }
}