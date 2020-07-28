using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wasm.Areas.Auth.Dtos;

namespace Wasm.Areas.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        private const string authUri = "https://localhost:9001/api/auth";


        public async Task<bool> Register(RegisterModel registerModel)
        {
            
            var result = await httpClient.PostAsJsonAsync<RegisterModel>($"{authUri}/signup", registerModel);

            return result.IsSuccessStatusCode;
        }

        public async Task Login(LoginModel loginModel)
        {
            var response = await httpClient.PostAsJsonAsync($"{authUri}/signin", loginModel);

            response.Headers.TryGetValues("Authorization", out var tokens);

            var token = tokens.FirstOrDefault();

            if (!response.IsSuccessStatusCode)
            {
                return ;
            }

            await _localStorage.SetItemAsync("authToken", token);
            ((CustomAuthStateProvider)_authenticationStateProvider).ModifyAuthState();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        public async Task Logout()
        {
            //await httpClient.PostAsync($"{authUri}/signout", null);

            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).ModifyAuthState();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
