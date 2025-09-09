
// The File Name GetBooks.cs  
// Vibe.Application / UseCases / Books / GetBooks.cs  
using Vibe.Domain.Repositories;
using VibeBooks.Domain.Entities;
 

namespace VibeBooks.Application.UseCases.Books;

public class GetBooks
{
    private readonly IBookRepository _repository;

    public Func<Guid, Book?> FindBook { get; }
    public Func<string, IEnumerable<Book>> FilterByAuthor { get; }

    public GetBooks(IBookRepository repository)
    {
        _repository = repository;

        FindBook = (Guid id) => _repository.GetById(id);
        FilterByAuthor = (string author) =>
            _repository.GetAll().Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
    }
}

