using System.Text.Json;
using Vibe.Domain.Repositories;
using VibeBooks.Domain.Entities;
 

namespace VibeBooks.Infrastructure.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly string _jsonFilePath;
    private readonly List<Book> _books;

    //public InMemoryBookRepository(string jsonFilePath = "books.json")
    //{
    //    if (!File.Exists(jsonFilePath))
    //    {
    //        _books = new List<Book>(); // empty if no file exists
    //        return;
    //    }

    //    var json = File.ReadAllText(jsonFilePath);

    //    // Deserialize to a list of Book objects
    //    _books = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    }) ?? new List<Book>();
    //}

    public InMemoryBookRepository(string? jsonFilePath = null)
    {
        // ✅ Always resolve from project root (where books.json is)
        var basePath = Directory.GetCurrentDirectory();
        _jsonFilePath = string.IsNullOrWhiteSpace(jsonFilePath)
            ? Path.Combine(basePath, "books.json") // look in Vibe.Api root
            : jsonFilePath;

        if (File.Exists(_jsonFilePath))
        {
            var json = File.ReadAllText(_jsonFilePath);
            _books = JsonSerializer.Deserialize<List<Book>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new List<Book>();
        }
        else
        {
            _books = new List<Book>();
        }
    }

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        var bookToAdd = book with { Id = book.Id == Guid.Empty ? Guid.NewGuid() : book.Id, Title=book.Title, Author=book.Author, Year=book.Year};
        _books.Add(bookToAdd);

        SaveChanges();
    }
    public void Update(Book book)
    {
        var existingIndex = _books.FindIndex(b => b.Id == book.Id);
        if (existingIndex == -1) return;

        _books[existingIndex] = book with { Id = book.Id , Title = book.Title, Author=book.Author, Year= book.Year};

        SaveChanges();
    }

    public void Delete(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book is not null)
        {
            _books.Remove(book);
            SaveChanges();
        }
    }

    private void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_jsonFilePath, json);
    }
}