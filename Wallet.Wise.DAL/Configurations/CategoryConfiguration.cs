using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.DAL.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.CategoryType)
            .IsRequired()
            .HasConversion(
                c => c.ToString(),
                c => (CategoryType)Enum.Parse(typeof(CategoryType), c));

        builder.Property(c => c.CurrencyCode)
            .IsRequired()
            .HasMaxLength(3);
    }
}