using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Wasm.Areas.Auth.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly IUniversalService universalService;

        public CustomAuthStateProvider(ILocalStorageService localStorage, IUniversalService universalService)
        {
            this.localStorage = localStorage;
            this.universalService = universalService;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await localStorage.GetItemAsStringAsync("authToken");

            if (string.IsNullOrEmpty(savedToken))
            {
                return new AuthenticationState( new ClaimsPrincipal( new ClaimsIdentity()));
            }

            var identity = new ClaimsIdentity(universalService.ParseClaimsFromJwt(savedToken), "jwtApi");

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }


        public void ModifyAuthState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
