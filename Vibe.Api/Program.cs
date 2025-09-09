using VibeBooks.Application.UseCases.Books;
using VibeBooks.Infrastructure.Repositories;
using VibeBooks.Api.Endpoints;
using Vibe.Domain.Repositories;
using VibeBooks.Application.UseCases.Users;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
builder.Services.AddSingleton<IGreeterService, GreeterService>();

var app = builder.Build();

// Endpoints
app.MapBookEndpoints();


app.MapGet("/greet/{name}", (string name, IGreeterService service) =>
{
    return service.Greet(name);
})
.WithName("GreetUser")
.Produces<string>(200);

app.Run();
