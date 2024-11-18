namespace Wallet.Wise.DAL.Entities;

public class Record
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Category_Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    
    public Category Category { get; set; }
    
}