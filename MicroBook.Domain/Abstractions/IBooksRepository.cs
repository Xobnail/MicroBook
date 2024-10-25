using MicroBook.Contracts;
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
    public Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates a book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>True if created, false if not.</returns>
    public Task<bool> CreateBookAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Updates a book.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <returns>True if updated, false if not.</returns>
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Updates book after order, decrease amount of books on storage.
    /// </summary>
    /// <param name="updateBooks">Book id and amount.</param>
    /// <returns>True if updated, false if not.</returns>
    public Task<bool> UpdateBookAfterOrderAsync(UpdateBook updateBooks);

    /// <summary>
    /// Deletes a book.
    /// </summary>
    /// <param name="id">Book id to delete.</param>
    /// <returns>True if deleted, false if not.</returns>
    public Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken);
}