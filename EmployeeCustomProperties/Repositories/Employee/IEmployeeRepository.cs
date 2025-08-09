using EmployeeCustomProperties.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Models.Employee>> GetAllWithPropertiesAsync();
        Task<Models.Employee?> GetByIdWithPropertiesAsync(int id);
        Task AddAsync(Models.Employee employee);
        Task AddEmployeePropertyValueAsync(EmployeePropertyValue value);
        Task UpdateAsync(Models.Employee employee);
        Task RemoveEmployeePropertyValuesAsync(int employeeId);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
