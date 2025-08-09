using EmployeeCustomProperties.Models;
namespace EmployeeCustomProperties.Repositories.Property
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Models.Property>> GetAllWithDropdownsAsync();
        Task AddAsync(Models.Property property);
        Task SaveAsync();
    }
}
