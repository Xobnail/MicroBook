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

        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                Name = "J. R. R. Tolkien",
                DateOfBirth = new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Author
            {
                Id = 2,
                Name = "Stephen King",
                DateOfBirth = new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 3,
                Name = "J. K. Rowling",
                DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 4,
                Name = "George R. R. Martin",
                DateOfBirth = new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 5,
                Name = "Suzanne Collins",
                DateOfBirth = new DateTime(1962, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 6,
                Name = "Veronica Roth",
                DateOfBirth = new DateTime(1988, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 7,
                Name = "Rick Riordan",
                DateOfBirth = new DateTime(1964, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 8,
                Name = "James Dashner",
                DateOfBirth = new DateTime(1972, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 9,
                Name = "Sarah J. Maas",
                DateOfBirth = new DateTime(1986, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            },
            new Author
            {
                Id = 10,
                Name = "Leigh Bardugo",
                DateOfBirth = new DateTime(1975, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                DateOfDeath = null
            }
        );

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Id = 1,
                Name = "George Allen & Unwin",
                ISBN = "978-0-618-05326-7",
                Site = "https://www.allendunwin.com/",
                FoundationDate = new DateTime(1930, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 2,
                Name = "Scribner",
                ISBN = "978-0-671-78922-1",
                Site = "https://www.simonandschuster.com/search/books/Scribner",
                FoundationDate = new DateTime(1846, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 3,
                Name = "Bloomsbury",
                ISBN = "978-0-7475-3269-0",
                Site = "https://us.bloomsbury.com/",
                FoundationDate = new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 4,
                Name = "Bantam Books",
                ISBN = "978-0-553-57342-2",
                Site = "https://www.randomhouse.com/bantam",
                FoundationDate = new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 5,
                Name = "Scholastic",
                ISBN = "978-0-545-01022-1",
                Site = "https://www.scholastic.com/",
                FoundationDate = new DateTime(1920, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 6,
                Name = "HarperCollins",
                ISBN = "978-0-06-195358-7",
                Site = "https://www.harpercollins.com/",
                FoundationDate = new DateTime(1817, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 7,
                Name = "Penguin Random House",
                ISBN = "978-0-14-311376-5",
                Site = "https://www.penguinrandomhouse.com/",
                FoundationDate = new DateTime(1935, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 8,
                Name = "Houghton Mifflin Harcourt",
                ISBN = "978-0-547-55044-8",
                Site = "https://www.hmhco.com/",
                FoundationDate = new DateTime(1832, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 9,
                Name = "Macmillan",
                ISBN = "978-1-4299-1392-6",
                Site = "https://us.macmillan.com/",
                FoundationDate = new DateTime(1843, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            },
            new Publisher
            {
                Id = 10,
                Name = "Simon & Schuster",
                ISBN = "978-1-4767-8324-2",
                Site = "https://www.simonandschuster.com/",
                FoundationDate = new DateTime(1924, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Name = "The Lord of the Rings",
                AuthorId = 1,
                Edition = "1st",
                AmountOfPages = 1216,
                Amount = 90,
                Language = "English",
                Price = 29.99m,
                Weight = "1.5",
                Size = "Large",
                PublishDate = new DateTime(1954, 07, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(1954, 07, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 1,
                ISBN = "978-0-618-05326-7",
                AgeRestrictions = "12"
            },
            new Book
            {
                Id = 2,
                Name = "The Hitchhiker's Guide to the Galaxy",
                AuthorId = 2,
                Edition = "1st",
                AmountOfPages = 213,
                Amount = 200,
                Language = "English",
                Price = 7.99m,
                Weight = "0.2",
                Size = "Small",
                PublishDate = new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 2,
                ISBN = "978-0-345-39180-3",
                AgeRestrictions = "0"
            },
            new Book
            {
                Id = 3,
                Name = "Harry Potter and the Sorcerer's Stone",
                AuthorId = 3,
                Edition = "1st",
                AmountOfPages = 309,
                Amount = 300,
                Language = "English",
                Price = 10.99m,
                Weight = "0.4",
                Size = "Medium",
                PublishDate = new DateTime(1997, 06, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(1997, 06, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 3,
                ISBN = "978-0-7475-3269-0",
                AgeRestrictions = "0"
            },
            new Book
            {
                Id = 4,
                Name = "A Game of Thrones",
                AuthorId = 4,
                Edition = "1st",
                AmountOfPages = 694,
                Amount = 250,
                Language = "English",
                Price = 8.99m,
                Weight = "1",
                Size = "Small",
                PublishDate = new DateTime(1996, 08, 06, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(1996, 08, 06, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 4,
                ISBN = "978-0-553-57342-2",
                AgeRestrictions = "18"
            },
            new Book
            {
                Id = 5,
                Name = "The Hunger Games",
                AuthorId = 5,
                Edition = "1st",
                AmountOfPages = 374,
                Amount = 400,
                Language = "English",
                Price = 9.99m,
                Weight = "0.6",
                Size = "Medium",
                PublishDate = new DateTime(2008, 09, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2008, 09, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 5,
                ISBN = "978-0-545-01022-1",
                AgeRestrictions = "14"
            },
            new Book
            {
                Id = 6,
                Name = "Divergent",
                AuthorId = 6,
                Edition = "1st",
                AmountOfPages = 487,
                Amount = 350,
                Language = "English",
                Price = 11.99m,
                Weight = "0.7",
                Size = "Medium",
                PublishDate = new DateTime(2011, 04, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2011, 04, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 6,
                ISBN = "978-0-06-195358-7",
                AgeRestrictions = "13"
            },
            new Book
            {
                Id = 7,
                Name = "Percy Jackson & the Olympians: The Lightning Thief",
                AuthorId = 7,
                Edition = "1st",
                AmountOfPages = 375,
                Amount = 500,
                Language = "English",
                Price = 8.99m,
                Weight = "0.5",
                Size = "Medium",
                PublishDate = new DateTime(2005, 06, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2005, 06, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 7,
                ISBN = "978-0-14-3111376-5",
                AgeRestrictions = "10"
            },
            new Book
            {
                Id = 8,
                Name = "The Maze Runner",
                AuthorId = 8,
                Edition = "1st",
                AmountOfPages = 391,
                Amount = 450,
                Language = "English",
                Price = 9.99m,
                Weight = "0.6",
                Size = "Medium",
                PublishDate = new DateTime(2009, 09, 08, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2009, 09, 08, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 8,
                ISBN = "978-0-547-55044-8",
                AgeRestrictions = "12"
            },
            new Book
            {
                Id = 9,
                Name = "Throne of Glass",
                AuthorId = 9,
                Edition = "1st",
                AmountOfPages = 490,
                Amount = 300,
                Language = "English",
                Price = 10.99m,
                Weight = "0.7",
                Size = "Medium",
                PublishDate = new DateTime(2012, 08, 07, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2012, 08, 07, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 9,
                ISBN = "978-1-4299-1392-6",
                AgeRestrictions = "15"
            },
            new Book
            {
                Id = 10,
                Name = "Shadow and Bone",
                AuthorId = 10,
                Edition = "1st",
                AmountOfPages = 469,
                Amount = 250,
                Language = "English",
                Price = 11.99m,
                Weight = "0.7",
                Size = "Medium",
                PublishDate = new DateTime(2012, 06, 05, 0, 0, 0, 0, DateTimeKind.Utc),
                ReleaseDate = new DateTime(2012, 06, 05, 0, 0, 0, 0, DateTimeKind.Utc),
                PublisherId = 10,
                ISBN = "978-1-4767-8324-2",
                AgeRestrictions = "14"
            }
        );
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //Unable to create a 'DbContext' of type ''.The exception 'The seed entity for entity type 'Book' 
        //    cannot be added because it has the navigation 'Author' set.To seed relationships,  add the entity
        //    seed to 'Book' and specify the foreign key values { 'AuthorId'}. Consider using
        //    'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the involved property values.
        //    ' was thrown while attempting to create an instance. For the different patterns supported at design time, 
        //    see https://go.microsoft.com/fwlink/?linkid=851728

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Name = "John Doe",
                Address = "123 Main St, Anytown, USA",
                Email = "john.doe@example.com",
                Phone = "555-123-4567"
            },
            new Customer
            {
                Id = 2,
                Name = "Jane Smith",
                Address = "456 Oak Ave, Springfield, USA",
                Email = "jane.smith@example.com",
                Phone = "555-987-6543"
            },
            new Customer
            {
                Id = 3,
                Name = "David Lee",
                Address = "789 Elm St, Willow Creek, USA",
                Email = "david.lee@example.com",
                Phone = "555-222-3333"
            },
            new Customer
            {
                Id = 4,
                Name = "Emily Brown",
                Address = "101 Pine Ln, Sunnyville, USA",
                Email = "emily.brown@example.com",
                Phone = "555-444-5555"
            },
            new Customer
            {
                Id = 5,
                Name = "Michael Wilson",
                Address = "202 Maple Rd, Rivertown, USA",
                Email = "michael.wilson@example.com",
                Phone = "555-666-7777"
            },
            new Customer
            {
                Id = 6,
                Name = "Jessica Davis",
                Address = "303 Birch Dr, Lakeview, USA",
                Email = "jessica.davis@example.com",
                Phone = "555-888-9999"
            },
            new Customer
            {
                Id = 7,
                Name = "Christopher Jones",
                Address = "404 Cedar Ave, Mountainside, USA",
                Email = "christopher.jones@example.com",
                Phone = "555-111-2222"
            },
            new Customer
            {
                Id = 8,
                Name = "Ashley Garcia",
                Address = "505 Oakwood Ln, Meadowbrook, USA",
                Email = "ashley.garcia@example.com",
                Phone = "555-333-4444"
            },
            new Customer
            {
                Id = 9,
                Name = "William Rodriguez",
                Address = "606 Willow St, Riverbend, USA",
                Email = "william.rodriguez@example.com",
                Phone = "555-555-6666"
            },
            new Customer
            {
                Id = 10,
                Name = "Sarah Miller",
                Address = "707 Pinewood Dr, Sun Valley, USA",
                Email = "sarah.miller@example.com",
                Phone = "555-777-8888"
            }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                OrderTime = new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 1,
                BookId = 1,
                Destination = "123 Main St, Anytown, USA"
            }
            ,
            new Order
            {
                Id = 2,
                OrderTime = new DateTime(2024, 9, 8, 0, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 3,
                BookId = 3,
                Destination = "789 Elm St, Willow Creek, USA"
            },
            new Order
            {
                Id = 3,
                OrderTime = new DateTime(2024, 9, 13, 2, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 4,
                BookId = 4,
                Destination = "101 Pine Ln, Sunnyville, USA"
            },
            new Order
            {
                Id = 4,
                OrderTime = new DateTime(2024, 9, 26, 4, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 5,
                BookId = 5,
                Destination = "202 Maple Rd, Rivertown, USA"
            },
            new Order
            {
                Id = 5,
                OrderTime = new DateTime(2024, 9, 20, 6, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 6,
                BookId = 6,
                Destination = "303 Birch Dr, Lakeview, USA"
            },
            new Order
            {
                Id = 6,
                OrderTime = new DateTime(2024, 9, 27, 8, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 7,
                BookId = 7,
                Destination = "404 Cedar Ave, Mountainside, USA"
            },
            new Order
            {
                Id = 7,
                OrderTime = new DateTime(2024, 9, 25, 10, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 8,
                BookId = 8,
                Destination = "505 Oakwood Ln, Meadowbrook, USA"
            },
            new Order
            {
                Id = 8,
                OrderTime = new DateTime(2024, 9, 20, 12, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 9,
                BookId = 9,
                Destination = "606 Willow St, Riverbend, USA"
            },
            new Order
            {
                Id = 9,
                OrderTime = new DateTime(2024, 9, 18, 14, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 10,
                BookId = 10,
                Destination = "707 Pinewood Dr, Sun Valley, USA"
            },
            new Order
            {
                Id = 10,
                OrderTime = new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc),
                CustomerId = 1,
                BookId = 1,
                Destination = "123 Main St, Anytown, USA"
            }
        );
    }
}