using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace Blazor.Utilities
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
