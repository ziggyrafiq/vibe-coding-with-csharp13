//The File Name  Book.cs
namespace VibeBooks.Domain.Entities;

public record Book(string Title, string Author, int Year)
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public void PrintInfo() => Console.WriteLine($"The {Title} by {Author}, published in {Year}.");
}
