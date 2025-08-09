using EmployeeCustomProperties.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCustomProperties.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<EmployeePropertyValue> EmployeePropertyValues { get; set; }
        public DbSet<DropdownValue> DropdownValues { get; set; }
    }
}
