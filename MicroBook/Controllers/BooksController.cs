using MicroBook.Domain.Abstractions;
using MicroBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroBook.Host.Controllers;

/// <summary>
/// Controller for working with books.
/// </summary>
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    /// <summary>
    /// Gets books.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of books.</returns>
    [HttpGet]
    [Route("Books/GetBooks")]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellationToken)
    {
        return Ok(await _booksRepository.GetBooksAsync(cancellationToken));
    }

    /// <summary>
    /// Creates a book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created book.</returns>
    [HttpPost]
    [Route("Books/CreateBook")]
    public async Task<IActionResult> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var isCreated = await _booksRepository.CreateBookAsync(book, cancellationToken);

        if (isCreated)
        {
            return Ok(book);
        }

        return BadRequest();
    }

    /// <summary>
    /// Updates a book.
    /// </summary>
    /// <param name="book">Book to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated book.</returns>
    [HttpPost]
    [Route("Books/UpdateBook")]
    public async Task<IActionResult> UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var isUpdated = await _booksRepository.UpdateBookAsync(book, cancellationToken);

        if (isUpdated)
        {
            return Ok(book);
        }

        return BadRequest();
    }

    /// <summary>
    /// Deletes a book.
    /// </summary>
    /// <param name="idToDelete">Book Id to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The result of removal.</returns>
    [HttpPost]
    [Route("Books/DeleteBook")]
    public async Task<IActionResult> DeleteBookAsync(int idToDelete, CancellationToken cancellationToken)
    {
        if (idToDelete == 0)
        {
            return BadRequest();
        }

        var isDeleted = await _booksRepository.DeleteBookAsync(idToDelete, cancellationToken);

        if (isDeleted)
        {
            return Ok();
        }

        return BadRequest();
    }
}