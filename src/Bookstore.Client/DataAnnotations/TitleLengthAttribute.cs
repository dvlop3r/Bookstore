using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class TitleLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value?.ToString()?.Length >= 3 && value?.ToString()?.Length <= 6
                ? ValidationResult.Success : new ValidationResult("Book title must be between 3 and 6 characters");
        }
    }
}
