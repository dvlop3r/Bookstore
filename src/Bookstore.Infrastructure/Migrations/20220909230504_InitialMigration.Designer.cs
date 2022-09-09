﻿// <auto-generated />
using System;
using Bookstore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookstore.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220909230504_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bookstore.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89944271-72e7-488d-8832-7e380d101739"),
                            Author = "Robert C. Martin",
                            BookUrl = "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882",
                            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Clean Code: A Handbook of Agile Software Craftsmanship",
                            IsDeleted = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Clean Code"
                        },
                        new
                        {
                            Id = new Guid("51b6bde2-10dc-43e2-94f4-d51e5e2a1c6a"),
                            Author = "Martin Fowler",
                            BookUrl = "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672",
                            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Refactoring: Improving the Design of Existing Code",
                            IsDeleted = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Refactoring"
                        },
                        new
                        {
                            Id = new Guid("ffc0f5b1-482b-4978-a79a-f31c1a967b25"),
                            Author = "Eric Evans",
                            BookUrl = "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215",
                            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                            IsDeleted = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishDate = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Domain-Driven Design"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
