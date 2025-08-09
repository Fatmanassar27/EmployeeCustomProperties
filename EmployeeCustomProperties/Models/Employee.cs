using System.ComponentModel.DataAnnotations;

namespace EmployeeCustomProperties.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Code ")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        public List<EmployeePropertyValue> PropertyValues { get; set; } = new List<EmployeePropertyValue>();
    }
}
