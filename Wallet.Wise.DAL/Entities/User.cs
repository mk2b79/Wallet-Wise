using Microsoft.AspNetCore.Identity;

namespace Wallet.Wise.DAL.Entities;

public class User:IdentityUser
{
    public virtual Account Account { get; set; }
}