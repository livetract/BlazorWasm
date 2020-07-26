using System.Threading.Tasks;

namespace Wasm.Areas.Auth.Dtos
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
