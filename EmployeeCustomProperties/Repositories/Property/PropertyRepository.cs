using EmployeeCustomProperties.Data;
using EmployeeCustomProperties.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Repositories.Property
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DBContext _context;

        public PropertyRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Property>> GetAllWithDropdownsAsync()
        {
            return await _context.Properties
                .Include(p => p.DropdownOptions)
                .ToListAsync();
        }

        public async Task AddAsync(Models.Property property)
        {   
            await _context.Properties.AddAsync(property);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Property?> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.DropdownOptions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Models.Property property)
        {
            _context.Properties.Update(property);
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
            }
        }
    }
}
