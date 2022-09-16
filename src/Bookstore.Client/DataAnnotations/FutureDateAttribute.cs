using Bookstore.Client.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value is not null && value is DateTime dateTime && dateTime.StartOfDay() >= DateTime.UtcNow.Date
                ? ValidationResult.Success : new ValidationResult("Date can't be in the past");
        }
    }
}
