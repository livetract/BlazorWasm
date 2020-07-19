using System.Threading.Tasks;
using JwtAuth.Entities;

namespace JwtAuth.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(IdentityUser user);
        Task<IdentityUser> GetByIdAsync(string id);
        Task<IdentityUser> GetByNameAsync(string name);
        
        Task<bool> FindByIdAsync(string id);
        Task<bool> FindByNameAsync(string name);
    }
}