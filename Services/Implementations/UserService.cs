using Microsoft.EntityFrameworkCore;
using ToDo_Ejercicio_Lab4.Data;
using ToDo_Ejercicio_Lab4.Data.Entities;
using ToDo_Ejercicio_Lab4.Services.Interfaces;

namespace ToDo_Ejercicio_Lab4.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly TodoContext _context;

        public UserService(TodoContext todoContext)
        {
            _context = todoContext; //inyección de dependencia
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id_User;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User userToBeDeleted = _context.Users.FirstOrDefault(u => u.Id_User == userId);
            userToBeDeleted.IsDeleted = true;
            _context.Update(userToBeDeleted);
            _context.SaveChanges();
        }
    }
}
