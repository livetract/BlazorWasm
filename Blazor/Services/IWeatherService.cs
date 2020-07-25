using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetDataAsync();

        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
    }
}