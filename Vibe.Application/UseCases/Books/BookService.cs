using Vibe.Domain.Repositories;
using VibeBooks.Application.Interfaces;
using VibeBooks.Domain.Entities;
 

namespace VibeBooks.Application.UseCases.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public Book? GetById(Guid id) => _repository.GetById(id);

    public List<Book> GetAll() => _repository.GetAll().ToList();

    public IEnumerable<Book> FilterByAuthor(string author) =>
        _repository.GetAll()
            .Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));

    public void AddBook(Book book)
    {
        if (book.Id == Guid.Empty)
        {
            book = book with { Id = Guid.NewGuid() };
        }

        _repository.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existing = _repository.GetById(book.Id);
        if (existing is null)
            throw new InvalidOperationException($"Book with Id {book.Id} not found.");

        _repository.Update(book);
    }

    public void DeleteBook(Guid id)
    {
        _repository.Delete(id);
    }


}
