using System.Threading.Tasks;
using JwtAuth.Data;
using JwtAuth.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public UserRepository(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        
        public async Task<bool> AddAsync(IdentityUser user)
        {
            await _context.LiveUsers.AddAsync(user);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IdentityUser> GetByIdAsync(string id)
        {
            return await _context.LiveUsers.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<IdentityUser> GetByNameAsync(string name)
        {
            return await _context.LiveUsers.FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<bool> FindByIdAsync(string id)
        {
            return await _context.LiveUsers.AnyAsync(x => x.Id.ToString() == id);
        }

        public async Task<bool> FindByNameAsync(string name)
        {
            return await _context.LiveUsers.AnyAsync(x => x.UserName == name);
        }
    }
}