﻿// <auto-generated />
using System;
using MicroBook.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicroBook.Host.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MicroBook.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            DateOfDeath = new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "J. R. R. Tolkien"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "J. K. Rowling"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "George R. R. Martin"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1962, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Suzanne Collins"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(1988, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Veronica Roth"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(1964, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Rick Riordan"
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(1972, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "James Dashner"
                        },
                        new
                        {
                            Id = 9,
                            DateOfBirth = new DateTime(1986, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Sarah J. Maas"
                        },
                        new
                        {
                            Id = 10,
                            DateOfBirth = new DateTime(1975, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Leigh Bardugo"
                        });
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRestrictions")
                        .HasColumnType("text");

                    b.Property<int?>("Amount")
                        .HasColumnType("integer");

                    b.Property<int?>("AmountOfPages")
                        .HasColumnType("integer");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Edition")
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<string>("Weight")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRestrictions = "12",
                            Amount = 90,
                            AmountOfPages = 1216,
                            AuthorId = 1,
                            Edition = "1st",
                            ISBN = "978-0-618-05326-7",
                            Language = "English",
                            Name = "The Lord of the Rings",
                            Price = 29.99m,
                            PublishDate = new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 1,
                            ReleaseDate = new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Large",
                            Weight = "1.5"
                        },
                        new
                        {
                            Id = 2,
                            AgeRestrictions = "0",
                            Amount = 200,
                            AmountOfPages = 213,
                            AuthorId = 2,
                            Edition = "1st",
                            ISBN = "978-0-345-39180-3",
                            Language = "English",
                            Name = "The Hitchhiker's Guide to the Galaxy",
                            Price = 7.99m,
                            PublishDate = new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 2,
                            ReleaseDate = new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Small",
                            Weight = "0.2"
                        },
                        new
                        {
                            Id = 3,
                            AgeRestrictions = "0",
                            Amount = 300,
                            AmountOfPages = 309,
                            AuthorId = 3,
                            Edition = "1st",
                            ISBN = "978-0-7475-3269-0",
                            Language = "English",
                            Name = "Harry Potter and the Sorcerer's Stone",
                            Price = 10.99m,
                            PublishDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 3,
                            ReleaseDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.4"
                        },
                        new
                        {
                            Id = 4,
                            AgeRestrictions = "18",
                            Amount = 250,
                            AmountOfPages = 694,
                            AuthorId = 4,
                            Edition = "1st",
                            ISBN = "978-0-553-57342-2",
                            Language = "English",
                            Name = "A Game of Thrones",
                            Price = 8.99m,
                            PublishDate = new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 4,
                            ReleaseDate = new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Small",
                            Weight = "1"
                        },
                        new
                        {
                            Id = 5,
                            AgeRestrictions = "14",
                            Amount = 400,
                            AmountOfPages = 374,
                            AuthorId = 5,
                            Edition = "1st",
                            ISBN = "978-0-545-01022-1",
                            Language = "English",
                            Name = "The Hunger Games",
                            Price = 9.99m,
                            PublishDate = new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 5,
                            ReleaseDate = new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.6"
                        },
                        new
                        {
                            Id = 6,
                            AgeRestrictions = "13",
                            Amount = 350,
                            AmountOfPages = 487,
                            AuthorId = 6,
                            Edition = "1st",
                            ISBN = "978-0-06-195358-7",
                            Language = "English",
                            Name = "Divergent",
                            Price = 11.99m,
                            PublishDate = new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 6,
                            ReleaseDate = new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.7"
                        },
                        new
                        {
                            Id = 7,
                            AgeRestrictions = "10",
                            Amount = 500,
                            AmountOfPages = 375,
                            AuthorId = 7,
                            Edition = "1st",
                            ISBN = "978-0-14-3111376-5",
                            Language = "English",
                            Name = "Percy Jackson & the Olympians: The Lightning Thief",
                            Price = 8.99m,
                            PublishDate = new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 7,
                            ReleaseDate = new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.5"
                        },
                        new
                        {
                            Id = 8,
                            AgeRestrictions = "12",
                            Amount = 450,
                            AmountOfPages = 391,
                            AuthorId = 8,
                            Edition = "1st",
                            ISBN = "978-0-547-55044-8",
                            Language = "English",
                            Name = "The Maze Runner",
                            Price = 9.99m,
                            PublishDate = new DateTime(2009, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 8,
                            ReleaseDate = new DateTime(2009, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.6"
                        },
                        new
                        {
                            Id = 9,
                            AgeRestrictions = "15",
                            Amount = 300,
                            AmountOfPages = 490,
                            AuthorId = 9,
                            Edition = "1st",
                            ISBN = "978-1-4299-1392-6",
                            Language = "English",
                            Name = "Throne of Glass",
                            Price = 10.99m,
                            PublishDate = new DateTime(2012, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 9,
                            ReleaseDate = new DateTime(2012, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.7"
                        },
                        new
                        {
                            Id = 10,
                            AgeRestrictions = "14",
                            Amount = 250,
                            AmountOfPages = 469,
                            AuthorId = 10,
                            Edition = "1st",
                            ISBN = "978-1-4767-8324-2",
                            Language = "English",
                            Name = "Shadow and Bone",
                            Price = 11.99m,
                            PublishDate = new DateTime(2012, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            PublisherId = 10,
                            ReleaseDate = new DateTime(2012, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Size = "Medium",
                            Weight = "0.7"
                        });
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Anytown, USA",
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Phone = "555-123-4567"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Oak Ave, Springfield, USA",
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Phone = "555-987-6543"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Elm St, Willow Creek, USA",
                            Email = "david.lee@example.com",
                            Name = "David Lee",
                            Phone = "555-222-3333"
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Pine Ln, Sunnyville, USA",
                            Email = "emily.brown@example.com",
                            Name = "Emily Brown",
                            Phone = "555-444-5555"
                        },
                        new
                        {
                            Id = 5,
                            Address = "202 Maple Rd, Rivertown, USA",
                            Email = "michael.wilson@example.com",
                            Name = "Michael Wilson",
                            Phone = "555-666-7777"
                        },
                        new
                        {
                            Id = 6,
                            Address = "303 Birch Dr, Lakeview, USA",
                            Email = "jessica.davis@example.com",
                            Name = "Jessica Davis",
                            Phone = "555-888-9999"
                        },
                        new
                        {
                            Id = 7,
                            Address = "404 Cedar Ave, Mountainside, USA",
                            Email = "christopher.jones@example.com",
                            Name = "Christopher Jones",
                            Phone = "555-111-2222"
                        },
                        new
                        {
                            Id = 8,
                            Address = "505 Oakwood Ln, Meadowbrook, USA",
                            Email = "ashley.garcia@example.com",
                            Name = "Ashley Garcia",
                            Phone = "555-333-4444"
                        },
                        new
                        {
                            Id = 9,
                            Address = "606 Willow St, Riverbend, USA",
                            Email = "william.rodriguez@example.com",
                            Name = "William Rodriguez",
                            Phone = "555-555-6666"
                        },
                        new
                        {
                            Id = 10,
                            Address = "707 Pinewood Dr, Sun Valley, USA",
                            Email = "sarah.miller@example.com",
                            Name = "Sarah Miller",
                            Phone = "555-777-8888"
                        });
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Destination")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            CustomerId = 1,
                            Destination = "123 Main St, Anytown, USA",
                            OrderTime = new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 3,
                            CustomerId = 3,
                            Destination = "789 Elm St, Willow Creek, USA",
                            OrderTime = new DateTime(2024, 9, 8, 0, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 4,
                            CustomerId = 4,
                            Destination = "101 Pine Ln, Sunnyville, USA",
                            OrderTime = new DateTime(2024, 9, 13, 2, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            BookId = 5,
                            CustomerId = 5,
                            Destination = "202 Maple Rd, Rivertown, USA",
                            OrderTime = new DateTime(2024, 9, 26, 4, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            BookId = 6,
                            CustomerId = 6,
                            Destination = "303 Birch Dr, Lakeview, USA",
                            OrderTime = new DateTime(2024, 9, 20, 6, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            BookId = 7,
                            CustomerId = 7,
                            Destination = "404 Cedar Ave, Mountainside, USA",
                            OrderTime = new DateTime(2024, 9, 27, 8, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            BookId = 8,
                            CustomerId = 8,
                            Destination = "505 Oakwood Ln, Meadowbrook, USA",
                            OrderTime = new DateTime(2024, 9, 25, 10, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            BookId = 9,
                            CustomerId = 9,
                            Destination = "606 Willow St, Riverbend, USA",
                            OrderTime = new DateTime(2024, 9, 20, 12, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            BookId = 10,
                            CustomerId = 10,
                            Destination = "707 Pinewood Dr, Sun Valley, USA",
                            OrderTime = new DateTime(2024, 9, 18, 14, 22, 19, 15, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            BookId = 1,
                            CustomerId = 1,
                            Destination = "123 Main St, Anytown, USA",
                            OrderTime = new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FoundationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ISBN")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Site")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Publishers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoundationDate = new DateTime(1930, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-618-05326-7",
                            Name = "George Allen & Unwin",
                            Site = "https://www.allendunwin.com/"
                        },
                        new
                        {
                            Id = 2,
                            FoundationDate = new DateTime(1846, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-671-78922-1",
                            Name = "Scribner",
                            Site = "https://www.simonandschuster.com/search/books/Scribner"
                        },
                        new
                        {
                            Id = 3,
                            FoundationDate = new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-7475-3269-0",
                            Name = "Bloomsbury",
                            Site = "https://us.bloomsbury.com/"
                        },
                        new
                        {
                            Id = 4,
                            FoundationDate = new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-553-57342-2",
                            Name = "Bantam Books",
                            Site = "https://www.randomhouse.com/bantam"
                        },
                        new
                        {
                            Id = 5,
                            FoundationDate = new DateTime(1920, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-545-01022-1",
                            Name = "Scholastic",
                            Site = "https://www.scholastic.com/"
                        },
                        new
                        {
                            Id = 6,
                            FoundationDate = new DateTime(1817, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-06-195358-7",
                            Name = "HarperCollins",
                            Site = "https://www.harpercollins.com/"
                        },
                        new
                        {
                            Id = 7,
                            FoundationDate = new DateTime(1935, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-14-311376-5",
                            Name = "Penguin Random House",
                            Site = "https://www.penguinrandomhouse.com/"
                        },
                        new
                        {
                            Id = 8,
                            FoundationDate = new DateTime(1832, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-0-547-55044-8",
                            Name = "Houghton Mifflin Harcourt",
                            Site = "https://www.hmhco.com/"
                        },
                        new
                        {
                            Id = 9,
                            FoundationDate = new DateTime(1843, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-1-4299-1392-6",
                            Name = "Macmillan",
                            Site = "https://us.macmillan.com/"
                        },
                        new
                        {
                            Id = 10,
                            FoundationDate = new DateTime(1924, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ISBN = "978-1-4767-8324-2",
                            Name = "Simon & Schuster",
                            Site = "https://www.simonandschuster.com/"
                        });
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Book", b =>
                {
                    b.HasOne("MicroBook.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_Book_Author");

                    b.HasOne("MicroBook.Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("FK_Book_Publisher");

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Order", b =>
                {
                    b.HasOne("MicroBook.Domain.Entities.Book", "Book")
                        .WithMany("Orders")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Order_Book");

                    b.HasOne("MicroBook.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customer");

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Book", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MicroBook.Domain.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
