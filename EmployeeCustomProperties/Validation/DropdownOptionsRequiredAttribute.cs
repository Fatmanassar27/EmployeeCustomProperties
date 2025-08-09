using System.ComponentModel.DataAnnotations;

namespace EmployeeCustomProperties.Validation
{
    public class DropdownOptionsRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = (Models.Property)validationContext.ObjectInstance;

            if (property.Type == Models.PropertyType.Dropdown)
            {
                if (property.DropdownOptions == null || !property.DropdownOptions.Any())
                {
                    return new ValidationResult("Please provide at least one dropdown option.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
