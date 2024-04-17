using ToDo_Ejercicio_Lab4.Data.Entities;

namespace ToDo_Ejercicio_Lab4.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByEmail(string email);
        public int CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
    }
}
