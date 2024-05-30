using ExampleApplication.Application.Interfaces;
using ExampleApplication.Infrastructure.Products;
using ExampleApplication.Infrastructure.ProductDataHolders;
using ExampleApplication.Application;
using ExampleApplication.Application.Products;
using ExampleApplication.Infrastructure;
using MediatR;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureDependencies();
builder.Services.AddApplicationDependencies();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();