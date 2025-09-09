using VibeBooks.Application.Interfaces;

namespace VibeBooks.Application.UseCases.Users;

public class GreeterService : IGreeterService
{
    public string Greet(string name) => $"Hello {name}, welcome to Ziggy Rafiq Vibe Coding Article!";
}
