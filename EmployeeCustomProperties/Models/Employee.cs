using System.ComponentModel.DataAnnotations;

namespace EmployeeCustomProperties.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the employee code.")]
        [StringLength(20, ErrorMessage = "Code cannot exceed 20 characters.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter the employee name.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public List<EmployeePropertyValue> PropertyValues { get; set; } = new List<EmployeePropertyValue>();
    }
}
