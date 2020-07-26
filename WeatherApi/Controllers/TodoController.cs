using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        public TodoController()
        {
            TodoItems = new List<Todo> {
                new Todo{Id = Guid.NewGuid(), Title = "创建Todo Item", Content = "创建 Todo Item 用来进行工作和任务的督导", IsCompleted = false},
                new Todo{Id = Guid.NewGuid(), Title = "吃晚饭", Content = "下班了，要按时吃晚饭。", IsCompleted = true}
                };
        }

        private readonly List<Todo> TodoItems;

        public ActionResult<IEnumerable<Todo>> GetItems()
        {


            return Ok(TodoItems);
        }
    }
}
