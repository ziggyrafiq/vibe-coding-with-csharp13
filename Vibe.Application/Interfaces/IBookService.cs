using VibeBooks.Domain.Entities;

namespace VibeBooks.Application.Interfaces;

public interface IBookService
{
    Book? GetById(Guid id);

    List<Book> GetAll();
    IEnumerable<Book> FilterByAuthor(string author);
    void AddBook(Book book);
    void UpdateBook(Book book);

    void DeleteBook(Guid id);
}
