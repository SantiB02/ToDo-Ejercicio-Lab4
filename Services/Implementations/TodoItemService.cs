using ToDo_Ejercicio_Lab4.Data;
using ToDo_Ejercicio_Lab4.Data.Entities;
using ToDo_Ejercicio_Lab4.Services.Interfaces;

namespace ToDo_Ejercicio_Lab4.Services.Implementations
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoContext _context;

        public TodoItemService(TodoContext todoContext)
        {
            _context = todoContext;
        }

        public TodoItem? GetTodoItemById(int itemId)
        {
            return _context.TodoItems.FirstOrDefault(ti => ti.Id_Todo_Item == itemId);
        }

        public List<TodoItem> GetTodoItemsForUser(int userId)
        {
            return _context.TodoItems.Where(ti => ti.CreatorId == userId).ToList();
        }

        public int CreateTodoItem(TodoItem todoItem)
        {
            _context.Add(todoItem);
            _context.SaveChanges();
            return todoItem.Id_Todo_Item;
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            _context.Update(todoItem);
            _context.SaveChanges();
        }

        public void DeleteTodoItem(int todoId)
        {
            TodoItem itemToBeDeleted = _context.TodoItems.FirstOrDefault(ti => ti.Id_Todo_Item == todoId);
            itemToBeDeleted.IsDeleted = true;
            _context.Update(itemToBeDeleted);
            _context.SaveChanges();
        }
    }
}
