using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace Webapp.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var shirt = validationContext.ObjectInstance as Shirt;

            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("For men's shirts, The size has to be bigger or equal to 8");
                }
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size > 6)
                {
                    return new ValidationResult("For women's shirts, The size has to be smaller or equal to 6");
                }
            }
            return ValidationResult.Success;
        }
    }
}
