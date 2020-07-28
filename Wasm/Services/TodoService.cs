using Blazored.LocalStorage;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wasm.Dtos;

namespace Wasm.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService localStorage;
        private const string BaseUri = "https://localhost:9011/api/todo";

        public TodoService(HttpClient httpClient,ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            this.localStorage = localStorage;
        }
        
        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {

            var token = await localStorage.GetItemAsStringAsync("authToken");
            if (string.IsNullOrEmpty(token))
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<TodoItem>>(BaseUri);
            }
            
            return await _httpClient.GetFromJsonAsync<IEnumerable<TodoItem>>(BaseUri);
        }
    }
}