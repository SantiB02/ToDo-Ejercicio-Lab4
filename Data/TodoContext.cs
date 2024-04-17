using Microsoft.EntityFrameworkCore;
using ToDo_Ejercicio_Lab4.Data.Entities;

namespace ToDo_Ejercicio_Lab4.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id_User = 1,
                    Name = "Default",
                    Email = "test",
                    Address = "random",
                }
                );

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id_Todo_Item = 1,
                    Title = "test title",
                    Description = "test description"
                }
                );

            modelBuilder.Entity<User>() //un user tiene muchos items
                .HasMany(u => u.TodoItems)
                .WithOne(ti => ti.Creator)
                .HasForeignKey(ti => ti.CreatorId);
        }
    }
}
