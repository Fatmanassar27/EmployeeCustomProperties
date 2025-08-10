namespace EmployeeCustomProperties.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Models.Property>> GetAllPropertiesWithDropdownsAsync();
        Task AddPropertyAsync(Models.Property property, List<string> dropdownOptions);
        Task UpdatePropertyAsync(Models.Property property, List<string> dropdownOptions);
        Task<Models.Property> GetByIdAsync(int id);
        Task DeletePropertyAsync(int id);

    }
}