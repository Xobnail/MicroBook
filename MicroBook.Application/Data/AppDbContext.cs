using MicroBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MicroBook.Application.Data;

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

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// Declares entities and their relationship in database.
    /// </summary>
    /// <param name="modelBuilder">Model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Declare tables
        modelBuilder.Entity<Author>().ToTable("Authors");
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<Publisher>().ToTable("Publishers");

        // Declare relationships
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Book_Author");
            entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_Book_Publisher");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");
            entity.HasOne(d => d.Book)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_Order_Book");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.SeedData();
    }
}