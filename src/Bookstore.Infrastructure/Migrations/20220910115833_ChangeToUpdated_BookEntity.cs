using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    public partial class ChangeToUpdated_BookEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("851a6b84-3d35-4a25-a51e-48f59ff7dd46"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c48c0fc9-4e4f-4099-9f7f-d115404db73f"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c7ae9b65-4ba7-42e9-b98b-02075a87e2b0"));

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                schema: "BS",
                table: "Books",
                newName: "Updated");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Updated",
                schema: "BS",
                table: "Books",
                newName: "UpdatedDateTime");

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "UpdatedDateTime" },
                values: new object[] { new Guid("851a6b84-3d35-4a25-a51e-48f59ff7dd46"), "Martin Fowler", "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672", "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring: Improving the Design of Existing Code", false, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "UpdatedDateTime" },
                values: new object[] { new Guid("c48c0fc9-4e4f-4099-9f7f-d115404db73f"), "Eric Evans", "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215", "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design: Tackling Complexity in the Heart of Software", false, new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "UpdatedDateTime" },
                values: new object[] { new Guid("c7ae9b65-4ba7-42e9-b98b-02075a87e2b0"), "Robert C. Martin", "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882", "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code: A Handbook of Agile Software Craftsmanship", false, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
