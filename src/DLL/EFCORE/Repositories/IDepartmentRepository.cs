using DLL.EFCORE.Model;

namespace DLL.EFCORE.Repositories
{
    public interface IDepartmentRepository: IRepository<Department>
    {
        
    }

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}