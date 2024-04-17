using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_Ejercicio_Lab4.Data.Entities;
using ToDo_Ejercicio_Lab4.Data.Models;
using ToDo_Ejercicio_Lab4.Services.Interfaces;

namespace ToDo_Ejercicio_Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetTodoItemsForUser([FromRoute] int userId)
        {
            return Ok(_todoItemService.GetTodoItemsForUser(userId));
        }

        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] TodoItemCreateDto todoItemDto)
        {
            TodoItem todoItem = new TodoItem()
            {
                Title = todoItemDto.Title,
                Description = todoItemDto.Description,
                CreatorId = todoItemDto.CreatorId,
            };
            int id = _todoItemService.CreateTodoItem(todoItem);
            return Ok(id);
        }

        [HttpPut("{itemId}")]
        public IActionResult UpdateTodoItem([FromRoute] int itemId, [FromBody] TodoItemUpdateDto todoItemUpdateDto)
        {
            TodoItem? todoItem = _todoItemService.GetTodoItemById(itemId);
            if (todoItem != null)
            {
                todoItem.Title = todoItemUpdateDto.Title;
                todoItem.Description = todoItemUpdateDto.Description;
                _todoItemService.UpdateTodoItem(todoItem);
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteTodoItem([FromRoute] int itemId)
        {
            if (_todoItemService.GetTodoItemById(itemId) != null)
            {
                _todoItemService.DeleteTodoItem(itemId);
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}
