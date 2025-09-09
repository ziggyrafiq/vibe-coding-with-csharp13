using VibeBooks.Domain.Entities;

namespace Vibe.Domain.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);

        void Add(Book book);

        void Update(Book book);

        void Delete(Guid id);
    }

}
