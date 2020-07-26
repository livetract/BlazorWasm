using System.Collections.Generic;
using System.Security.Claims;

namespace Wasm.Areas.Auth.Services
{
    public interface IUniversalService
    {
        IEnumerable<Claim> ParseClaimsFromJwt(string token);
    }
}
