using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Repositories.Property;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Services
{
    public class PropertyService : IPropertyService
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
        public async Task<Property> GetByIdAsync(int id)
        {
            return await _propertyRepository.GetByIdAsync(id);
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
        public async Task UpdatePropertyAsync(Property property, List<string> dropdownOptions)
        {
            if (property.Type == PropertyType.Dropdown && dropdownOptions != null)
            {
                property.DropdownOptions = dropdownOptions
                    .Where(v => !string.IsNullOrWhiteSpace(v))
                    .Select(v => new DropdownValue { Value = v })
                    .ToList();
            }
            else
            {
                property.DropdownOptions = new List<DropdownValue>();
            }

            await _propertyRepository.UpdateAsync(property);
            await _propertyRepository.SaveAsync();
        }

        public async Task DeletePropertyAsync(int id)
        {
            await _propertyRepository.DeleteAsync(id);
            await _propertyRepository.SaveAsync();
        }
    }
}
