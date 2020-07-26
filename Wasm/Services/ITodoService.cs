using System.Collections.Generic;
using System.Threading.Tasks;
using Wasm.Dtos;

namespace Wasm.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetItemsAsync();
    }
}