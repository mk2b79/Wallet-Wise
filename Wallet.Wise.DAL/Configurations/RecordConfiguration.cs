using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.DAL.Configurations;

public class RecordConfiguration:IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Category_Id)
            .IsRequired();

        builder.Property(r => r.Amount)
            .IsRequired();

        builder.Property(r => r.Date)
            .IsRequired();

        builder.HasOne(r => r.Category)
            .WithMany(c => c.Records)
            .HasForeignKey(r => r.Category_Id);
    }
}