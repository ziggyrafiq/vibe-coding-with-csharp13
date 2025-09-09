using VibeBooks.Domain.Entities;

namespace VibeBooks.Api.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books/{id}", (Guid id, IBookService service) =>
        {
            var book = service.GetById(id);

            if (book is { Title: not null, Year: > 2000 })
                return Results.Ok(book);

            return Results.NotFound();
        });

        app.MapGet("/books/all", (IBookService service) =>
         {
             var book = service.GetAll();

             if (book is not null)
                 return Results.Ok(book);

             return Results.NotFound();
         });

        app.MapGet("/books/author/{author}", (string author, IBookService service) =>
        {
            var books = service.FilterByAuthor(author);
            if (books.Any())
                return Results.Ok(books);
            return Results.NotFound();
        });

        
        app.MapPost("/books", (Book book, IBookService service) =>
        {
            service.AddBook(book);
            return Results.Created($"/books/{book.Id}", book);
        });

        
        app.MapPut("/books/{id}", (Guid id, Book book, IBookService service) =>
        {
            if (id != book.Id)
                return Results.BadRequest("Book ID in URL and body do not match.");

            var existing = service.GetById(id);
            if (existing is null)
                return Results.NotFound();

            service.UpdateBook(book);
            return Results.Ok(book);
        });

        
        app.MapDelete("/books/{id}", (Guid id, IBookService service) =>
        {
            var existing = service.GetById(id);
            if (existing is null)
                return Results.NotFound();

            service.DeleteBook(id);
            return Results.NoContent();
        });
    }
}