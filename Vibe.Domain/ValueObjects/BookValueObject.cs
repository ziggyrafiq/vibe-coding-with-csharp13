// File: BookValueObject.cs
namespace Vibe.Domain.ValueObjects;

/// <summary>
/// Represents a Book as a Value Object in the domain.
/// Value Objects are immutable and compared by the values of their properties.
/// </summary>
public sealed record BookValueObject
{
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }

    public BookValueObject(string title, string author, int year)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author cannot be null or empty.", nameof(author));

        if (year < 1440 || year > DateTime.UtcNow.Year)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 1440 and current year.");

        Title = title;
        Author = author;
        Year = year;
    }

    public void PrintInfo() =>
        Console.WriteLine($"The {Title} by {Author}, published in {Year}.");
}
