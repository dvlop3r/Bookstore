using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books","BS");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Author).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(500).IsRequired();
        builder.Property(b => b.PublishDate).IsRequired();
    }
}