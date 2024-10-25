using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Book.
/// </summary>
public class Book
{
    /// <summary>
    /// Book Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Book name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Book's author.
    /// </summary>
    [ForeignKey("Id")]
    public Author Author { get; set; } = new Author();

    /// <summary>
    /// Book's author Id.
    /// </summary>
    public int AuthorId { get; set; }

    /// <summary>
    /// Book edition.
    /// </summary>
    public string Edition { get; set; } = string.Empty;

    /// <summary>
    /// Amount of pages in book.
    /// </summary>
    public int AmountOfPages { get; set; }

    /// <summary>
    /// Amount of books on storage.
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Language of book.
    /// </summary>
    public string Language { get; set; } = string.Empty;

    /// <summary>
    /// Book price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Weight of book.
    /// </summary>
    public string Weight { get; set; } = string.Empty;

    /// <summary>
    /// Size of book.
    /// </summary>
    public string Size { get; set; } = string.Empty;

    /// <summary>
    /// Book publish date.
    /// </summary>
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// Book release date.
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Book's publisher.
    /// </summary>
    [ForeignKey("Id")]
    public Publisher Publisher { get; set; } = new Publisher();

    /// <summary>
    /// Book's publisher Id.
    /// </summary>
    public int PublisherId { get; set; }

    /// <summary>
    /// Book's ISBN.
    /// </summary>
    public string ISBN { get; set; } = string.Empty;

    /// <summary>
    /// Age restriction of book.
    /// </summary>
    public string AgeRestrictions { get; set; } = string.Empty;
}