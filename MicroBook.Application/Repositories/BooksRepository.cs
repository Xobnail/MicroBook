using MicroBook.Domain.Abstractions;
using MicroBook.Contracts;
using MicroBook.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading;

namespace MicroBook.Application.Repositories;

/// <summary>
/// Repository for working with Books.
/// </summary>
public class BooksRepository : IBooksRepository
{
    private const string BooksKey = "books";
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _cache;

    public BooksRepository(IDistributedCache cache, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    /// <summary>
    /// Gets books.
    /// </summary>
    /// <returns>List of books.</returns>
    public async Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken)
    {
        var cachedBooks = await _cache.GetStringAsync(BooksKey, cancellationToken);

        List<Book> books;
        if (string.IsNullOrEmpty(cachedBooks))
        {
            books = await _dbContext.Book
                .Include(book => book.Author)
                .Include(book => book.Publisher)
                .ToListAsync(cancellationToken);

            if (books is null || books.Count == 0)
            {
                return [];
            }

            await _cache.SetStringAsync(BooksKey, JsonSerializer.Serialize(books), 
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                }, cancellationToken);

            return books;
        }

        return JsonSerializer.Deserialize<List<Book>>(cachedBooks) ?? [];
    }

    /// <summary>
    /// Creates book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>True if created, false if not.</returns>
    public async Task<bool> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        _dbContext.Book.Add(book);
        await _cache.RemoveAsync(BooksKey, cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    /// <summary>
    /// Updates book.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <returns>True if updated, false if not.</returns>
    public async Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken)
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

        await _cache.RemoveAsync(BooksKey, cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    /// <summary>
    /// Updates book after order, decrease amount of books on storage.
    /// </summary>
    /// <param name="updateBooks">Book id and amount.</param>
    /// <returns>True if updated, false if not.</returns>
    public async Task<bool> UpdateBookAfterOrderAsync(UpdateBook updateBooks)
    {
        var bookToUpdate = _dbContext.Book.Find(updateBooks.BookId);

        if (bookToUpdate == null || bookToUpdate.Amount < 1)
        {
            return false;
        }

        bookToUpdate.Amount -= updateBooks.Amount;

        await _cache.RemoveAsync(BooksKey);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Deletes book.
    /// </summary>
    /// <param name="id">Book id to delete.</param>
    /// <returns>True if deleted, false if not.</returns>
    public async Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken)
    {
        var bookToDelete = _dbContext.Book.Find(id);

        if (bookToDelete == null)
        {
            return false;
        }

        _dbContext.Book.Remove(bookToDelete);

        await _cache.RemoveAsync(BooksKey, cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}