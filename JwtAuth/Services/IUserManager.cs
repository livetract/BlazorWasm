using System.Threading.Tasks;
using JwtAuth.Dtos;
using JwtAuth.Entities;

namespace JwtAuth.Services
{
    public interface IUserManager
    {
        Task<bool> CreatUserAsync(RegisterDto model);
        Task<IdentityUser>  FindByNameAsync(string name);
        Task<IdentityUser>  FindByIdAsync(string id);
        
        Task<bool> IsExists(string name);
    }
}