using System.Threading.Tasks;

namespace JwtAuth.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}