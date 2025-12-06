using System.ComponentModel.DataAnnotations;

namespace WebapiNet10.Models.Shirts.Validations
{
    public class CorrectSizingAttribute : ValidationAttribute
    {
        private const string maleGender = "men";
        private const string femaleGender = "women";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            
            var shirtDto = validationContext.ObjectInstance switch
            {
                CreateShirtDto dto => dto.ToDto(),
                ShirtDto dto => dto,
                _ => null,
            };

            if (shirtDto == null)
            {
                return new ValidationResult("Invalid shirt object for sizing validation.");
            }

            var (isValid, errorMessage) = GetValidationResult(shirtDto.Gender, shirtDto.Size);

            return isValid ? ValidationResult.Success : new ValidationResult(errorMessage ?? "Shirt size validation failed.");
        }

        private (bool isValid, string ErrorMessage) GetValidationResult(string gender, int size)
        {
            var errorFormat = "For {0} shirts, size must be greater than or equal to {1}";

            if (gender.Equals(maleGender, StringComparison.OrdinalIgnoreCase))
            {
                return size >= 8 || size == 0
                    ? (true, string.Empty)
                    : (false, string.Format(errorFormat, maleGender, 8));
            }

            if (gender.Equals(femaleGender, StringComparison.OrdinalIgnoreCase))
            {
                return size >= 6 || size == 0
                    ? (true, string.Empty)
                    : (false, string.Format(errorFormat, femaleGender, 6));
            }

            return (false, "Invalid gender input.");
        }
    }
}
