using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.EFCORE;
using DLL.EFCORE.Model;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IDepartmentService
    {
        Task<Department> Add(Department department);
        Task<List<Department>> GetAll();
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Add(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<List<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}