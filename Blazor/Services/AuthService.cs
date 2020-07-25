using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.Models;
using Blazor.Utilities;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(IHttpClientFactory httpClientFactory,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var client = _httpClientFactory.CreateClient("auth");
            var result = await client.PostAsJsonAsync<RegisterModel>("auth/signup", registerModel);
            var res = result.IsSuccessStatusCode;
            return res;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var client = _httpClientFactory.CreateClient("auth");

            var response = await client.PostAsJsonAsync("auth/signin", loginModel);

            var header = response.Headers.TryGetValues("Authorization", out var tokens);

            var token = tokens.FirstOrDefault();
            
            if (!response.IsSuccessStatusCode)
            {
                return "登录失败";
            }

            await _localStorage.SetItemAsync("authToken", token);
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return "登录成功";
        }

        public async Task Logout()
        {
            var client = _httpClientFactory.CreateClient("auth");
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            client.DefaultRequestHeaders.Authorization = null;
        }
    }
}