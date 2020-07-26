using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wasm.Areas.Auth.Services;
using Wasm.Services;

namespace Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddScoped<IUniversalService, UniversalService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddOidcAuthentication(options => { builder.Configuration.Bind("Local", options.ProviderOptions); });

            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}