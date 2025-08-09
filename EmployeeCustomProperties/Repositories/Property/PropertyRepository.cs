using EmployeeCustomProperties.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
