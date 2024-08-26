using Microsoft.EntityFrameworkCore;
using UserService;
using UserService.Implements;
using UserService.Interfaces;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register the UserService with dependency injection
builder.Services.AddScoped<IUsersService, UsersService>();

// Add services to the container.
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
