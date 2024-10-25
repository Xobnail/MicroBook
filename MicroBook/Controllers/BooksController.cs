using MicroBook.Domain.Abstractions;
using MicroBook.Domain.Entities;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MicroBook.Host.Controllers;

public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    [HttpGet]
    [Route("Books/GetBooks")]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellationToken)
    {
        return Ok(await _booksRepository.GetBooksAsync(cancellationToken));
    }

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