using System.ComponentModel.DataAnnotations;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Customer.
/// </summary>
public class Customer
{
    /// <summary>
    /// Customer Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Customer name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Customer address.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Customer Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Customer phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// One to many relationship with Orders.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = [];
}