using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Book>? Books { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasIndex(b => b.Title);
        
        builder.Entity<Book>().HasData(
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Description = "Clean Code: A Handbook of Agile Software Craftsmanship",
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zymoq7UnL._SX379_BO1,204,203,200_.jpg",
                BookUrl = "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882",
                PublishDate = new DateTime(2008, 8, 1),
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Refactoring",
                Author = "Martin Fowler",
                Description = "Refactoring: Improving the Design of Existing Code",
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZyvZ9ZGJL._SX379_BO1,204,203,200_.jpg",
                BookUrl = "https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672",
                PublishDate = new DateTime(2018, 7, 8),
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Description = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51p1Y8JN3aL._SX379_BO1,204,203,200_.jpg",
                BookUrl = "https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215",
                PublishDate = new DateTime(2003, 8, 30),
            }
        );
    }
}