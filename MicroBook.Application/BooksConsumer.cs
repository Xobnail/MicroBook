using MassTransit;
using MicroBook.Domain.Abstractions;
using MicroBook.Contracts;

namespace MicroBook.Application;

public class BooksConsumer : IConsumer<UpdateBook>
{
    private readonly IBooksRepository _booksRepository;

    public BooksConsumer(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task Consume(ConsumeContext<UpdateBook> context)
    {
        await _booksRepository.UpdateBookAfterOrderAsync(context.Message);
    }
}