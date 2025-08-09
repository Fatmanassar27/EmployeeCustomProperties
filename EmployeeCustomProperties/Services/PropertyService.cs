using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Repositories.Property;

namespace EmployeeCustomProperties.Services
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesWithDropdownsAsync()
        {
            return await _propertyRepository.GetAllWithDropdownsAsync();
        }

        public async Task AddPropertyAsync(Property property, List<string> dropdownOptions)
        {
            if (property.Type == PropertyType.Dropdown && dropdownOptions != null)
            {
                property.DropdownOptions = dropdownOptions
                    .Where(v => !string.IsNullOrWhiteSpace(v))
                    .Select(v => new DropdownValue { Value = v })
                    .ToList();
            }

            await _propertyRepository.AddAsync(property);
            await _propertyRepository.SaveAsync();
        }
    }
}
