using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    public partial class MakeCoverImageUrlAndBookUrlNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                schema: "BS",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookUrl",
                schema: "BS",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("0e12e3c7-62f1-4c35-a444-830172d75f27"), "Martin Fowler", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring desc", false, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("443b54ef-f4c1-43af-9574-fc6f94a8f45f"), "Eric Evans", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design desc", false, new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "BS",
                table: "Books",
                columns: new[] { "Id", "Author", "BookUrl", "CoverImageUrl", "Created", "Description", "IsDeleted", "PublishDate", "Title", "Updated" },
                values: new object[] { new Guid("c0c28969-28ce-4353-b128-594289b971b8"), "Robert C. Martin", "book url", "cover image url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code desc", false, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0e12e3c7-62f1-4c35-a444-830172d75f27"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("443b54ef-f4c1-43af-9574-fc6f94a8f45f"));

            migrationBuilder.DeleteData(
                schema: "BS",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c0c28969-28ce-4353-b128-594289b971b8"));

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                schema: "BS",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookUrl",
                schema: "BS",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
