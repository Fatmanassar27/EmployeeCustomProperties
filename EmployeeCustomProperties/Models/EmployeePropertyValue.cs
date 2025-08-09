using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCustomProperties.Models
{
    public class EmployeePropertyValue
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

    }
}