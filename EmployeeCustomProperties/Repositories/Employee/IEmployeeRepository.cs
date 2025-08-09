using EmployeeCustomProperties.Models;
namespace EmployeeCustomProperties.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Models.Employee>> GetAllAsync();
        Task<Models.Employee> GetByIdAsync(int id);
        Task AddAsync(Models.Employee employee);
        Task UpdateAsync(Models.Employee employee);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
