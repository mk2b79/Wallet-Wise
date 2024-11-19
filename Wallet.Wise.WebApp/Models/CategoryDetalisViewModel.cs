using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.WebApp.Models;

public class CategoryDetalisViewModel
{
    public Category Category { get; set; }
    public IEnumerable<Record> Records { get; set; }
}