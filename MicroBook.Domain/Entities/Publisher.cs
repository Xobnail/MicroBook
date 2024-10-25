using System.ComponentModel.DataAnnotations;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Publisher.
/// </summary>
public class Publisher
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Publisher name.
    /// </summary>
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// Publisher ISBN.
    /// </summary>
    public string? ISBN { get; set; } = string.Empty;

    /// <summary>
    /// Publisher site.
    /// </summary>
    public string? Site { get; set; } = string.Empty;

    /// <summary>
    /// Publisher foundation date.
    /// </summary>
    public DateTime? FoundationDate { get; set; }
}