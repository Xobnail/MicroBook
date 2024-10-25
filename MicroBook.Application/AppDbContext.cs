using MicroBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroBook.Application;

/// <summary>
/// Contains MicroBook DbSet.
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Publisher> Publisher { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}