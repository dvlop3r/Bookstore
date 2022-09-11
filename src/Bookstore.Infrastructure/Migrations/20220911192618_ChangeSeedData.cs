using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    public partial class ChangeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("35367a0f-b0ba-44e5-8542-7c6546b5ca98"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6ad1e9c2-6a99-47b1-8661-6b6742e6b456"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e62dbdab-4cc9-4477-8ca3-b026b875fb78"));

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("42bcfefd-9ac3-4937-9edb-778511fdd4be"), "Eric Evans", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design desc", false, new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("c279ecb1-b3f7-48af-8673-b46788fc8aa6"), "Robert C. Martin", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code desc", false, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("c352f8c0-0074-4e49-afd6-6cdf3328c39a"), "Martin Fowler", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring desc", false, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("42bcfefd-9ac3-4937-9edb-778511fdd4be"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c279ecb1-b3f7-48af-8673-b46788fc8aa6"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c352f8c0-0074-4e49-afd6-6cdf3328c39a"));

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("35367a0f-b0ba-44e5-8542-7c6546b5ca98"), "Martin Fowler", "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672", "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring: Improving the Design of Existing Code", false, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("6ad1e9c2-6a99-47b1-8661-6b6742e6b456"), "Eric Evans", "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215", "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design: Tackling Complexity in the Heart of Software", false, new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("e62dbdab-4cc9-4477-8ca3-b026b875fb78"), "Robert C. Martin", "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882", "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code: A Handbook of Agile Software Craftsmanship", false, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
