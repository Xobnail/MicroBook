using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Order.
/// </summary>
public class Order
{
    /// <summary>
    /// Order Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Order time.
    /// </summary>
    public DateTime? OrderTime { get; set; }

    /// <summary>
    /// Customer.
    /// </summary>
    [ForeignKey("Id")]
    public Customer? Customer { get; set; }

    /// <summary>
    /// Customer Id.
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Book.
    /// </summary>
    [ForeignKey("Id")]
    public Book? Book { get; set; }

    /// <summary>
    /// Book Id.
    /// </summary>
    public int? BookId { get; set; }

    /// <summary>
    /// Destination.
    /// </summary>
    public string? Destination { get; set; }
}