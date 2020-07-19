using System.Threading.Tasks;
using JwtAuth.Data;

namespace JwtAuth.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}