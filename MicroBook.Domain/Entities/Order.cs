using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBook.Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    public DateTime OrderTime { get; set; }

    [ForeignKey("Id")]
    public Customer Customer { get; set; } = new Customer();
    public int CustomerId { get; set; }

    [ForeignKey("Id")]
    public Book Book { get; set; } = new Book();
    public int BookId { get; set; }

    public string Destination { get; set; } = string.Empty;
}