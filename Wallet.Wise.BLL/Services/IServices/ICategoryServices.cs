using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services.IServices;

public interface ICategoryServices
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}