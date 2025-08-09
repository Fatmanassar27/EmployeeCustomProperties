using System.ComponentModel.DataAnnotations;

namespace EmployeeCustomProperties.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public PropertyType Type { get; set; }
        public bool IsRequired { get; set; } = false;   

        public List<DropdownValue> DropdownOptions { get; set; } = new List<DropdownValue>();
    }
}
