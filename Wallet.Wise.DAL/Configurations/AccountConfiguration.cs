using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.DAL.Configurations;

public class AccountConfiguration:IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a=>a.AccountId);

        builder.Property(a => a.AccountId)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId);
    }
}