using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Repositories.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesWithPropertiesAsync()
        {
            return await _employeeRepository.GetAllWithPropertiesAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdWithPropertiesAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee, Dictionary<int, string> propertyValues)
        {
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();
            if (propertyValues == null)
                propertyValues = new Dictionary<int, string>();
            foreach (var prop in propertyValues)
            {
                if (string.IsNullOrWhiteSpace(prop.Value))
                    continue;

                var value = new EmployeePropertyValue
                {
                    EmployeeId = employee.Id,
                    PropertyId = prop.Key,
                    Value = prop.Value
                };

                await _employeeRepository.AddEmployeePropertyValueAsync(value);
            }

            await _employeeRepository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee, Dictionary<int, string> propertyValues)
        {
            await _employeeRepository.UpdateAsync(employee);

            await _employeeRepository.RemoveEmployeePropertyValuesAsync(employee.Id);

            foreach (var prop in propertyValues)
            {
                if (string.IsNullOrWhiteSpace(prop.Value))
                    continue;

                var value = new EmployeePropertyValue
                {
                    EmployeeId = employee.Id,
                    PropertyId = prop.Key,
                    Value = prop.Value
                };

                await _employeeRepository.AddEmployeePropertyValueAsync(value);
            }

            await _employeeRepository.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            await _employeeRepository.SaveAsync();
        }
    }
}
