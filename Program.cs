using Microsoft.EntityFrameworkCore;
using ToDo_Ejercicio_Lab4.Data;
using ToDo_Ejercicio_Lab4.Services.Implementations;
using ToDo_Ejercicio_Lab4.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString"]));

#region Injections
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
