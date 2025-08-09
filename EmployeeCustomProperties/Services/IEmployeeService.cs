using EmployeeCustomProperties.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesWithPropertiesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee, Dictionary<int, string> propertyValues);
        Task UpdateEmployeeAsync(Employee employee, Dictionary<int, string> propertyValues);
        Task DeleteEmployeeAsync(int id);
    }
}
