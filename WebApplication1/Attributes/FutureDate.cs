using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if(date <= DateTime.Now)
                {
                    return new ValidationResult("The date must be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
