using EmployeeCustomProperties.Data;
using EmployeeCustomProperties.Models;
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

        public async Task<IEnumerable<Models.Employee>> GetAllWithPropertiesAsync()
        {
            return await _context.Employees
                .Include(e => e.PropertyValues)
                .ThenInclude(v => v.Property)
                .ToListAsync();
        }

        public async Task AddAsync(Models.Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task AddEmployeePropertyValueAsync(EmployeePropertyValue value)
        {
            await _context.EmployeePropertyValues.AddAsync(value);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}