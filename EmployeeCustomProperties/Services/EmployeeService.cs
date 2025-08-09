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

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            await _employeeRepository.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            await _employeeRepository.SaveAsync();
        }
    }
}
