using MicroBook.Domain.Entities;

namespace MicroBook.Domain.Abstractions;

/// <summary>
/// Repository for working with Books.
/// </summary>
public interface IBooksRepository
{
    /// <summary>
    /// Gets books.
    /// </summary>
    /// <returns>List of books.</returns>
    public List<Book> GetBooks();

    /// <summary>
    /// Creates a book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>True if created, false if not.</returns>
    public Task<bool> CreateBookAsync(Book book);

    /// <summary>
    /// Updates a book.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <returns>True if updated, false if not.</returns>
    public Task<bool> UpdateBookAsync(Book book);

    /// <summary>
    /// Deletes a book.
    /// </summary>
    /// <param name="id">Book id to delete.</param>
    /// <returns>True if deleted, false if not.</returns>
    public Task<bool> DeleteBookAsync(int id);
}