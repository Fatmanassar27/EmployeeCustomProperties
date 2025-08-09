namespace EmployeeCustomProperties.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Models.Property>> GetAllPropertiesWithDropdownsAsync();
        Task AddPropertyAsync(Models.Property property, List<string> dropdownOptions);
    }
}