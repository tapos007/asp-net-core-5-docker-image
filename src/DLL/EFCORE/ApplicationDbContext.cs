using DLL.EFCORE.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL.EFCORE
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Department> Departments { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}