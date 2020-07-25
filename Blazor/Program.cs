using Blazor.Services;
using Blazor.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            
            builder.Services.AddHttpClient("weather", client => client.BaseAddress = new Uri("https://localhost:9011/api/"));
            builder.Services.AddHttpClient("auth", client => client.BaseAddress = new Uri("https://localhost:9001/api/"));

            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}