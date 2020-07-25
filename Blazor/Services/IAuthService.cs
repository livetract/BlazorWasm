using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel loginModel);
        Task Logout();
        Task<bool> Register(RegisterModel registerModel);
    }
}