using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Context;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class CategoryServices:ICategoryServices
{
    private readonly WalletWiseContext _context;
    public CategoryServices(WalletWiseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    
    public async Task<IEnumerable<Category>> GetAllByMountAsync(DateTime mount)
    {
        return await _context.Categories
            .Where(c => c.Records.Any(r => r.Date.Year == mount.Year && r.Date.Month == mount.Month))
            .ToListAsync();
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