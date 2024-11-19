using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.DTOs
{
    public class CategoryWithAmontDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public CategoryType CategoryType { get; set; }
        public decimal Amount { get; set; }
    }
}
