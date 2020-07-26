using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wasm.Dtos;

namespace Wasm.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUri = "https://localhost:9011/api/";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<WeatherForecast>> GetDataAsync()
        {
            var data =await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>($"{BaseUri}weatherforecast");
            return data;
        }
        
        
    }
}