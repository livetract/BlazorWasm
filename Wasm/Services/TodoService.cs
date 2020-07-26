using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wasm.Dtos;

namespace Wasm.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUri = "https://localhost:9011/api/todo";

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TodoItem>>(BaseUri);
        }
    }
}