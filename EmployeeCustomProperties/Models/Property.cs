using System.ComponentModel.DataAnnotations;

namespace EmployeeCustomProperties.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the property name.")]
        [StringLength(100, ErrorMessage = "Property name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select the property type.")]
        public PropertyType? Type { get; set; }

        public bool IsRequired { get; set; } = false;
        public List<DropdownValue> DropdownOptions { get; set; } = new List<DropdownValue>();
    }
}
