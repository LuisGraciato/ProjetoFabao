using System.ComponentModel.DataAnnotations;

namespace DevIOApi.Attributes
{
    public class AdultAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateOfBirth = (DateTime?)value;

            if (dateOfBirth.HasValue && dateOfBirth.Value.AddYears(18) <= DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "O cliente deve ser maior de 18 anos.");
        }
    }
}
