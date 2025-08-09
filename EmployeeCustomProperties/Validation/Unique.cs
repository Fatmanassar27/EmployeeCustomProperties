using System.ComponentModel.DataAnnotations;
using EmployeeCustomProperties.Data;

public class Unique : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var context = (DBContext)validationContext.GetService(typeof(DBContext));

        var code = value?.ToString();

        if (string.IsNullOrWhiteSpace(code))
            return ValidationResult.Success;
        var instance = validationContext.ObjectInstance;
        var employee = instance as EmployeeCustomProperties.Models.Employee;
        var currentEmployeeId = employee?.Id ?? 0;

        var exists = context.Employees.Any(e => e.Code == code && e.Id != currentEmployeeId);

        if (exists)
            return new ValidationResult("This employee code already exists.");

        return ValidationResult.Success;
    }
}
