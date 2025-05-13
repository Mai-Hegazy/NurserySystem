using System.ComponentModel.DataAnnotations;

namespace NurserySystem.Application.Validators
{
    public class FutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                if (birthDate > DateTime.Today)
                    return new ValidationResult("Birth date cannot be in the future.");
            }
            return  ValidationResult.Success;
        }
    }
}