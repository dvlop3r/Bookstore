using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BS");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "BS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                schema: "BS",
                table: "Books",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "BS");
        }
    }
}
