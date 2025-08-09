using System.ComponentModel.DataAnnotations;
using EmployeeCustomProperties.Data;

namespace EmployeeCustomProperties.Validation
{
    public class Unique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (DBContext)validationContext.GetService(typeof(DBContext));

            var code = value?.ToString();

            if (string.IsNullOrWhiteSpace(code))
                return ValidationResult.Success;

            var exists = context.Employees.Any(e => e.Code == code);

            if (exists)
                return new ValidationResult("This employee code already exists.");

            return ValidationResult.Success;
        }
    }
}
