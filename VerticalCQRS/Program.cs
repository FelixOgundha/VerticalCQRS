using Carter;
using Microsoft.EntityFrameworkCore;
using VerticalCQRS.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));

// Add services to the container.
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();




app.MapCarter();
app.Run();


