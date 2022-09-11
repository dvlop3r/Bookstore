using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasIndex(b => b.Title);
        builder.HasDefaultSchema("BS");
        
        builder.Entity<Book>().HasData(
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Description = "Clean Code desc",
                CoverImageUrl = "cover image url",
                BookUrl = "book url",
                PublishDate = new DateTime(2008, 8, 1),
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Refactoring",
                Author = "Martin Fowler",
                Description = "Refactoring desc",
                CoverImageUrl = "cover image url",
                BookUrl = "book url",
                PublishDate = new DateTime(2018, 7, 8),
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Description = "Domain-Driven Design desc",
                CoverImageUrl = "cover image url",
                BookUrl = "book url",
                PublishDate = new DateTime(2003, 8, 30),
            }
        );
    }
}