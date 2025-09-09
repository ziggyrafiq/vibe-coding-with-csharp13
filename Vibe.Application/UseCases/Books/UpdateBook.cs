using Vibe.Domain.Repositories;
using VibeBooks.Domain.Entities;

namespace Vibe.Application.UseCases.Books;

public class UpdateBook
{
    private readonly IBookRepository _repository;

    public Action<Book> Update { get; }

    public UpdateBook(IBookRepository repository)
    {
        _repository = repository;

        Update = (Book book) => _repository.Update(book);
    }
}
