using System.ComponentModel.DataAnnotations;

namespace MicroBook.Domain.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}