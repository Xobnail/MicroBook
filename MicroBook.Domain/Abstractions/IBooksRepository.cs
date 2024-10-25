using MicroBook.Contracts;
using MicroBook.Domain.Entities;

namespace MicroBook.Domain.Abstractions;

/// <summary>
/// Repository for working with Books.
/// </summary>
public interface IBooksRepository
{
    /// <summary>
    /// Gets books from cache, if there is no one, load it from database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of books.</returns>
    public Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates book and clears cache.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if created, false if not.</returns>
    public Task<bool> CreateBookAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Updates book and clears cache.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if updated, false if not.</returns>
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Updates book after order, decrease amount of books on storage and clears cache.
    /// </summary>
    /// <param name="updateBooks">Book id and amount.</param>
    /// <returns>True if updated, false if not.</returns>
    public Task<bool> UpdateBookAfterOrderAsync(UpdateBook updateBooks);

    /// <summary>
    /// Deletes book and clears cache.
    /// </summary>
    /// <param name="id">Book id to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if deleted, false if not.</returns>
    public Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken);
}