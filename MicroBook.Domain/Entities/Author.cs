using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Author.
/// </summary>
public class Author
{
    /// <summary>
    /// Author Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Author name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Author's date of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Author's date of death.
    /// </summary>
    public DateTime? DateOfDeath { get; set; }

    /// <summary>
    /// One to many relationship with books.
    /// </summary>
    [JsonIgnore]
    public ICollection<Book> Books { get; set; } = [];
}