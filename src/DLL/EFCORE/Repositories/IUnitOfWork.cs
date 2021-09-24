using System;
using System.Threading.Tasks;

namespace DLL.EFCORE.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}