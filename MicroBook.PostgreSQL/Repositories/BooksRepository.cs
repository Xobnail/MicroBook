using MicroBook.Domain.Abstractions;
using MicroBook.Domain.Entities;

namespace MicroBook.PostgreSQL.Repositories;

/// <summary>
/// Repository for working with Books.
/// </summary>
public class BooksRepository : IBooksRepository
{
    private readonly AppDbContext _dbContext;

    public BooksRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets books.
    /// </summary>
    /// <returns>List of books.</returns>
    public List<Book> GetBooks()
    {
        return _dbContext.Book.ToList();
    }

    /// <summary>
    /// Creates book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>True if created, false if not.</returns>
    public async Task<bool> CreateBookAsync(Book book)
    {
        _dbContext.Book.Add(book);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Updates book.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <returns>True if updated, false if not.</returns>
    public async Task<bool> UpdateBookAsync(Book book)
    {
        var bookToUpdate = _dbContext.Book.Find(book.Id);

        if (bookToUpdate == null)
        {
            return false;
        }

        bookToUpdate.Name = book.Name;
        bookToUpdate.Author = book.Author;
        bookToUpdate.Edition = book.Edition;
        bookToUpdate.AmountOfPages = book.AmountOfPages;
        bookToUpdate.Amount = book.Amount;
        bookToUpdate.Language = book.Language;
        bookToUpdate.Price = book.Price;
        bookToUpdate.Weight = book.Weight;
        bookToUpdate.Size = book.Size;
        bookToUpdate.PublishDate = book.PublishDate;
        bookToUpdate.ReleaseDate = book.ReleaseDate;
        bookToUpdate.Publisher = book.Publisher;
        bookToUpdate.ISBN = book.ISBN;
        bookToUpdate.AgeRestrictions = book.AgeRestrictions;

        return await _dbContext.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Deletes book.
    /// </summary>
    /// <param name="id">Book id to delete.</param>
    /// <returns>True if deleted, false if not.</returns>
    public async Task<bool> DeleteBookAsync(int id)
    {
        var bookToDelete = _dbContext.Book.Find(id);

        if (bookToDelete == null)
        {
            return false;
        }

        _dbContext.Book.Remove(bookToDelete);

        return await _dbContext.SaveChangesAsync() > 0;
    }
}