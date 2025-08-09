using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCustomProperties.Models
{
    public class DropdownValue
    {
        public int Id { get; set; }
        public string Value { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}