using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.DTOs;
using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Context;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class CategoryServices:ICategoryServices
{
    private readonly WalletWiseContext _context;
    private readonly IMapper _mapper;
    public CategoryServices(WalletWiseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    
    //public async Task<IEnumerable<Category>> GetAllByMountAsync(DateTime mount)
    //{
    //    return await _context.Categories
    //        .Where(c => c.Records.Any(r => r.Date.Year == mount.Year && r.Date.Month == mount.Month))
    //        .ToListAsync();
    //}

    public async Task<IEnumerable<CategoryWithAmontDto>> GetAllByMountAsync(DateTime mount)
    {
        var categories = await _context.Categories
            .Include(c => c.Records.Where(r=>r.Date.Year==mount.Year && r.Date.Month==mount.Month))
            .ToListAsync();
        return _mapper.Map<List<CategoryWithAmontDto>>(categories);
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
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