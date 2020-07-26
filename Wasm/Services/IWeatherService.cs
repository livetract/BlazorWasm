using System.Collections.Generic;
using System.Threading.Tasks;
using Wasm.Dtos;

namespace Wasm.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetDataAsync();
    }
}