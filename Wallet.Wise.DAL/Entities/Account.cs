namespace Wallet.Wise.DAL.Entities;

public class Account
{
    public int AccountId { get; set; }
    public string UserId { get; set; }
    
    public virtual User User { get; set; }
}