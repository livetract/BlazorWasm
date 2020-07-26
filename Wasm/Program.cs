using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<ITodoService, TodoService>();

            builder.Services.AddOidcAuthentication(options => { builder.Configuration.Bind("Local", options.ProviderOptions); });
            await builder.Build().RunAsync();
        }
    }
}