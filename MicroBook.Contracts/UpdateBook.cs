namespace MicroBook.Contracts;

public record UpdateBook
{
    public int BookId { get; init; }
    public int Amount { get; init; }
}