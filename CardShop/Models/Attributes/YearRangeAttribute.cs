using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.Attributes
{
    public class YearRangeAttribute : ValidationAttribute
    {
        private readonly int _minYear;

        public YearRangeAttribute(int minYear)
        {
            _minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                short year = (short)DateTime.Now.Year;

                if ((short)value < _minYear && (short)value > year)
                {
                    return new ValidationResult($"The {validationContext.DisplayName} must be between {_minYear} and {year}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
