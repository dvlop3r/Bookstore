using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    public partial class ChangeModifiedToUpdated_BookEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("51b6bde2-10dc-43e2-94f4-d51e5e2a1c6a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("89944271-72e7-488d-8832-7e380d101739"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ffc0f5b1-482b-4978-a79a-f31c1a967b25"));

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Books",
                newName: "Updated");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("06446e78-8d2d-4a8c-9b0f-2fd020d1da84"), "Robert C. Martin", "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882", "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code: A Handbook of Agile Software Craftsmanship", false, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("81208890-6c45-42a6-a256-9476f116690b"), "Eric Evans", "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215", "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design: Tackling Complexity in the Heart of Software", false, new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("8eb9b9a6-678a-4f56-b2b0-9501128dd105"), "Martin Fowler", "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672", "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring: Improving the Design of Existing Code", false, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("06446e78-8d2d-4a8c-9b0f-2fd020d1da84"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("81208890-6c45-42a6-a256-9476f116690b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8eb9b9a6-678a-4f56-b2b0-9501128dd105"));

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Books",
                newName: "Modified");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "Modified", "PublishDate", "Title" },
                values: new object[] { new Guid("51b6bde2-10dc-43e2-94f4-d51e5e2a1c6a"), "Martin Fowler", "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672", "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring: Improving the Design of Existing Code", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "Modified", "PublishDate", "Title" },
                values: new object[] { new Guid("89944271-72e7-488d-8832-7e380d101739"), "Robert C. Martin", "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882", "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code: A Handbook of Agile Software Craftsmanship", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "Modified", "PublishDate", "Title" },
                values: new object[] { new Guid("ffc0f5b1-482b-4978-a79a-f31c1a967b25"), "Eric Evans", "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215", "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design: Tackling Complexity in the Heart of Software", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design" });
        }
    }
}
