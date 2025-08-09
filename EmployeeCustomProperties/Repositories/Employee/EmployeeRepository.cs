using EmployeeCustomProperties.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCustomProperties.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext _context;

        public EmployeeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Models.Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Models.Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task UpdateAsync(Models.Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp != null)
                _context.Employees.Remove(emp);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
