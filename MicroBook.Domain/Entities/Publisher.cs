using System.ComponentModel.DataAnnotations;

namespace MicroBook.Domain.Entities;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
}