using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.DAL.Context;

public class WalletWiseContext:DbContext
{
    public WalletWiseContext(DbContextOptions options):base(options)
    {}

    public DbSet<Category> Categories { get; set; }
    public DbSet<Record> Records { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}