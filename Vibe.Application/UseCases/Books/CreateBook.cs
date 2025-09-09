using Vibe.Domain.Repositories;
using VibeBooks.Domain.Entities;

namespace Vibe.Application.UseCases.Books;

public class CreateBook
{
    private readonly IBookRepository _repository;

    public Action<Book> Add { get; }

    public CreateBook(IBookRepository repository)
    {
        _repository = repository;

        Add = (Book book) => _repository.Add(book);
    }
}
