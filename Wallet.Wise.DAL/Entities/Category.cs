using System.Security.Cryptography;

namespace Wallet.Wise.DAL.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public CategoryType CategoryType { get; set; }
    
    // public Currency Currency { get; set; }
}