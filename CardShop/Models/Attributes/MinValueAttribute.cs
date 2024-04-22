using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly double _minValue;

        public MinValueAttribute(double minValue)
        {
            _minValue = minValue;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && (double)value < _minValue)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be greater than or equal to {_minValue}.");
            }

            return ValidationResult.Success;
        }
    }
}
