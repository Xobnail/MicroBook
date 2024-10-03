using MicroBook.Domain.Abstractions;
using MicroBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetBooks()
    {
        return Ok(_booksRepository.GetBooks());
    }

    [HttpPost]
    [Route("Books/CreateBook")]
    public async Task<IActionResult> CreateBookAsync(Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var isCreated = await _booksRepository.CreateBookAsync(book);

        if (isCreated)
        {
            return Ok(book);
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("Books/UpdateBook")]
    public async Task<IActionResult> UpdateBookAsync(Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var isUpdated = await _booksRepository.UpdateBookAsync(book);

        if (isUpdated)
        {
            return Ok(book);
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("Books/DeleteBook")]
    public async Task<IActionResult> DeleteBookAsync(int idToDelete)
    {
        if (idToDelete == 0)
        {
            return BadRequest();
        }

        var isDeleted = await _booksRepository.DeleteBookAsync(idToDelete);

        if (isDeleted)
        {
            return Ok();
        }

        return BadRequest();
    }
}