using System.Threading.Tasks;
using Wasm.Areas.Auth.Dtos;

namespace Wasm.Areas.Auth.Services
{
    public interface IAuthService
    {
        Task Login(LoginModel loginModel);
        Task Logout();
        Task<bool> Register(RegisterModel registerModel);
    }
}
