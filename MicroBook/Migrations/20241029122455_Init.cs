using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroBook.Host.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ISBN = table.Column<string>(type: "text", nullable: true),
                    Site = table.Column<string>(type: "text", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    Edition = table.Column<string>(type: "text", nullable: true),
                    AmountOfPages = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Weight = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PublisherId = table.Column<int>(type: "integer", nullable: true),
                    ISBN = table.Column<string>(type: "text", nullable: true),
                    AgeRestrictions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Book_Publisher",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    BookId = table.Column<int>(type: "integer", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Book",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1111, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "J. R. R. Tolkien" },
                    { 2, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, "Stephen King" },
                    { 3, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, "J. K. Rowling" },
                    { 4, new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, "George R. R. Martin" },
                    { 5, new DateTime(1962, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, "Suzanne Collins" },
                    { 6, new DateTime(1988, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Veronica Roth" },
                    { 7, new DateTime(1964, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, "Rick Riordan" },
                    { 8, new DateTime(1972, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), null, "James Dashner" },
                    { 9, new DateTime(1986, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, "Sarah J. Maas" },
                    { 10, new DateTime(1975, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, "Leigh Bardugo" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", "john.doe@example.com", "John Doe", "555-123-4567" },
                    { 2, "456 Oak Ave, Springfield, USA", "jane.smith@example.com", "Jane Smith", "555-987-6543" },
                    { 3, "789 Elm St, Willow Creek, USA", "david.lee@example.com", "David Lee", "555-222-3333" },
                    { 4, "101 Pine Ln, Sunnyville, USA", "emily.brown@example.com", "Emily Brown", "555-444-5555" },
                    { 5, "202 Maple Rd, Rivertown, USA", "michael.wilson@example.com", "Michael Wilson", "555-666-7777" },
                    { 6, "303 Birch Dr, Lakeview, USA", "jessica.davis@example.com", "Jessica Davis", "555-888-9999" },
                    { 7, "404 Cedar Ave, Mountainside, USA", "christopher.jones@example.com", "Christopher Jones", "555-111-2222" },
                    { 8, "505 Oakwood Ln, Meadowbrook, USA", "ashley.garcia@example.com", "Ashley Garcia", "555-333-4444" },
                    { 9, "606 Willow St, Riverbend, USA", "william.rodriguez@example.com", "William Rodriguez", "555-555-6666" },
                    { 10, "707 Pinewood Dr, Sun Valley, USA", "sarah.miller@example.com", "Sarah Miller", "555-777-8888" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "FoundationDate", "ISBN", "Name", "Site" },
                values: new object[,]
                {
                    { 1, new DateTime(1930, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-618-05326-7", "George Allen & Unwin", "https://www.allendunwin.com/" },
                    { 2, new DateTime(1846, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-671-78922-1", "Scribner", "https://www.simonandschuster.com/search/books/Scribner" },
                    { 3, new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-7475-3269-0", "Bloomsbury", "https://us.bloomsbury.com/" },
                    { 4, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-553-57342-2", "Bantam Books", "https://www.randomhouse.com/bantam" },
                    { 5, new DateTime(1920, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-545-01022-1", "Scholastic", "https://www.scholastic.com/" },
                    { 6, new DateTime(1817, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-06-195358-7", "HarperCollins", "https://www.harpercollins.com/" },
                    { 7, new DateTime(1935, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-14-311376-5", "Penguin Random House", "https://www.penguinrandomhouse.com/" },
                    { 8, new DateTime(1832, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-0-547-55044-8", "Houghton Mifflin Harcourt", "https://www.hmhco.com/" },
                    { 9, new DateTime(1843, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-1-4299-1392-6", "Macmillan", "https://us.macmillan.com/" },
                    { 10, new DateTime(1924, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "978-1-4767-8324-2", "Simon & Schuster", "https://www.simonandschuster.com/" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeRestrictions", "Amount", "AmountOfPages", "AuthorId", "Edition", "ISBN", "Language", "Name", "Price", "PublishDate", "PublisherId", "ReleaseDate", "Size", "Weight" },
                values: new object[,]
                {
                    { 1, "12", 90, 1216, 1, "1st", "978-0-618-05326-7", "English", "The Lord of the Rings", 29.99m, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Large", "1.5" },
                    { 2, "0", 200, 213, 2, "1st", "978-0-345-39180-3", "English", "The Hitchhiker's Guide to the Galaxy", 7.99m, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Small", "0.2" },
                    { 3, "0", 300, 309, 3, "1st", "978-0-7475-3269-0", "English", "Harry Potter and the Sorcerer's Stone", 10.99m, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.4" },
                    { 4, "18", 250, 694, 4, "1st", "978-0-553-57342-2", "English", "A Game of Thrones", 8.99m, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Small", "1" },
                    { 5, "14", 400, 374, 5, "1st", "978-0-545-01022-1", "English", "The Hunger Games", 9.99m, new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.6" },
                    { 6, "13", 350, 487, 6, "1st", "978-0-06-195358-7", "English", "Divergent", 11.99m, new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.7" },
                    { 7, "10", 500, 375, 7, "1st", "978-0-14-3111376-5", "English", "Percy Jackson & the Olympians: The Lightning Thief", 8.99m, new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), 7, new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.5" },
                    { 8, "12", 450, 391, 8, "1st", "978-0-547-55044-8", "English", "The Maze Runner", 9.99m, new DateTime(2009, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2009, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.6" },
                    { 9, "15", 300, 490, 9, "1st", "978-1-4299-1392-6", "English", "Throne of Glass", 10.99m, new DateTime(2012, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), 9, new DateTime(2012, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.7" },
                    { 10, "14", 250, 469, 10, "1st", "978-1-4767-8324-2", "English", "Shadow and Bone", 11.99m, new DateTime(2012, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), 10, new DateTime(2012, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Medium", "0.7" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BookId", "CustomerId", "Destination", "OrderTime" },
                values: new object[,]
                {
                    { 1, 1, 1, "123 Main St, Anytown, USA", new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc) },
                    { 2, 3, 3, "789 Elm St, Willow Creek, USA", new DateTime(2024, 9, 8, 0, 22, 19, 15, DateTimeKind.Utc) },
                    { 3, 4, 4, "101 Pine Ln, Sunnyville, USA", new DateTime(2024, 9, 13, 2, 22, 19, 15, DateTimeKind.Utc) },
                    { 4, 5, 5, "202 Maple Rd, Rivertown, USA", new DateTime(2024, 9, 26, 4, 22, 19, 15, DateTimeKind.Utc) },
                    { 5, 6, 6, "303 Birch Dr, Lakeview, USA", new DateTime(2024, 9, 20, 6, 22, 19, 15, DateTimeKind.Utc) },
                    { 6, 7, 7, "404 Cedar Ave, Mountainside, USA", new DateTime(2024, 9, 27, 8, 22, 19, 15, DateTimeKind.Utc) },
                    { 7, 8, 8, "505 Oakwood Ln, Meadowbrook, USA", new DateTime(2024, 9, 25, 10, 22, 19, 15, DateTimeKind.Utc) },
                    { 8, 9, 9, "606 Willow St, Riverbend, USA", new DateTime(2024, 9, 20, 12, 22, 19, 15, DateTimeKind.Utc) },
                    { 9, 10, 10, "707 Pinewood Dr, Sun Valley, USA", new DateTime(2024, 9, 18, 14, 22, 19, 15, DateTimeKind.Utc) },
                    { 10, 1, 1, "123 Main St, Anytown, USA", new DateTime(2024, 9, 17, 20, 22, 19, 15, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
