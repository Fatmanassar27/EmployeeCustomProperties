using EmployeeCustomProperties.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Repositories.Property
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Models.Property>> GetAllWithDropdownsAsync();
        Task AddAsync(Models.Property property);
        Task<Models.Property?> GetByIdAsync(int id);
        Task UpdateAsync(Models.Property property);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
