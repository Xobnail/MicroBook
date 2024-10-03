using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBook.Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [ForeignKey("Id")]
    public Author Author { get; set; } = new Author();
    public int AuthorId { get; set; }

    public string Edition { get; set; } = string.Empty;

    public int AmountOfPages { get; set; }

    public int Amount { get; set; }

    public string Language { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Weight { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public DateTime PublishDate { get; set; }

    public DateTime ReleaseDate { get; set; }

    [ForeignKey("Id")]
    public Publisher Publisher { get; set; } = new Publisher();
    public int PublisherId { get; set; }

    public string ISBN { get; set; } = string.Empty;

    public string AgeRestrictions { get; set; } = string.Empty;
}
