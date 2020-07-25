using System;

namespace Blazor.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsCompleted { get; set; }
    }
}
