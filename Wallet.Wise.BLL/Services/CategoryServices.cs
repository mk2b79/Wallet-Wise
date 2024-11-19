using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class CategoryServices:ICategoryServices
{
    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}