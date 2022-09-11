using FluentValidation;
using MediatR;

namespace Bookstore.Application.ValidationBehavior;

public class ValidationBehavior<TRequest, TResponse> :
                        IPipelineBehavior<TRequest, TResponse>
                        where TRequest : IRequest<TResponse>
                        //where TResponse : 
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if(_validator is null)
            return await next();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        if(!validationResult.IsValid)
            throw new ValidationException("badd", validationResult.Errors);
            // throw new BadRequestException("badd",errors);

        return await next();
    }

}
