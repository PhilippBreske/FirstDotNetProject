using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);


//use controllers with endpoints
builder.Services.AddControllers();

// Make the ProductHolder class available for dependency injection
builder.Services.AddSingleton<ProductHolder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseHttpsRedirection();

//Add the ProductsController to the application
app.MapControllers();

app.Run();