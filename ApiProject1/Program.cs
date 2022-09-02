using ApiProject1.Interface;
using ApiProject1.Services;
using Microsoft.AspNetCore.Mvc;
using apiProject1_lib;
using Microsoft.EntityFrameworkCore;
//make all files as api ctrl by applying it in the assembly level
[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegister, RegisterService>();
builder.Services.AddScoped<IProject, ProjectService>();
builder.Services.AddScoped<ITask, TaskService>();
builder.Services.AddDbContext<task_managerContext>(option => option.UseSqlServer("Data Source=DESKTOP-LK2QAA8\\SQLEXPRESS;Initial Catalog=task_manager;Integrated Security=True"));
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
