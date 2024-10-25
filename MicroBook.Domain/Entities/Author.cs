using System.ComponentModel.DataAnnotations;

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
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// Author's date of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Author's date of death.
    /// </summary>
    public DateTime? DateOfDeath { get; set; }
}