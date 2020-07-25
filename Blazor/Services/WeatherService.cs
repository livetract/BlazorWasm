using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IEnumerable<WeatherForecast>> GetDataAsync()
        {
            var client = _httpClientFactory.CreateClient("weather");
            var data = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("weatherforecast");
            return data;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            var client = _httpClientFactory.CreateClient("weather");
            var data = await client.GetFromJsonAsync<IEnumerable<TodoItem>>("todo");
            return data;
        }
    }
}