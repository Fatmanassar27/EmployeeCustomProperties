using EmployeeCustomProperties.Models;
namespace EmployeeCustomProperties.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Models.Employee>> GetAllWithPropertiesAsync();
        Task AddAsync(Models.Employee employee);
        Task AddEmployeePropertyValueAsync(EmployeePropertyValue value);
        Task SaveAsync();
    }
}
