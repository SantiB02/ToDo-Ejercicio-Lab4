using ToDo_Ejercicio_Lab4.Data.Entities;

namespace ToDo_Ejercicio_Lab4.Services.Interfaces
{
    public interface ITodoItemService
    {
        public List<TodoItem> GetTodoItemsForUser(int userId);
        public int CreateTodoItem(TodoItem todoItem);
        public void UpdateTodoItem(TodoItem todoItem);
        public void DeleteTodoItem(int todoId);
    }
}
