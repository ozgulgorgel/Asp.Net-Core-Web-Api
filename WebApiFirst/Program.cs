using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebApiFirst.Data.Context;
using WebApiFirst.Data.Repositories;
using WebApiFirst.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>();

//depnendency injection - service registration
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<BookRepository>();
//string connectionString = builder.Configuration.GetConnectionString("SqlServer");
//builder.Services.AddDbContext<BookContext>(opt =>
//{
//    opt.UseSqlServer(connectionString);
//});

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
