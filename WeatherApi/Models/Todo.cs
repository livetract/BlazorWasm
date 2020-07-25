using System;

namespace WeatherApi.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsCompleted { get; set; }
    }
}
