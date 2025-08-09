using EmployeeCustomProperties.Data;
using EmployeeCustomProperties.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Models.Employee?> GetByIdWithPropertiesAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.PropertyValues)
                .ThenInclude(v => v.Property)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Models.Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task AddEmployeePropertyValueAsync(EmployeePropertyValue value)
        {
            await _context.EmployeePropertyValues.AddAsync(value);
        }

        public async Task RemoveEmployeePropertyValuesAsync(int employeeId)
        {
            var values = _context.EmployeePropertyValues.Where(v => v.EmployeeId == employeeId);
            _context.EmployeePropertyValues.RemoveRange(values);
        }


        public async Task UpdateAsync(Models.Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
