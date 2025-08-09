using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Repositories.Employee;

namespace EmployeeCustomProperties.Services
{
    public class EmployeeService
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

        public async Task AddEmployeeAsync(Employee employee, Dictionary<int, string> propertyValues)
        {
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();

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
    }
}
