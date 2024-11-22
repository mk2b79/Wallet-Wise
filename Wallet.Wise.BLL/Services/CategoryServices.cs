using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.DTOs;
using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Context;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class CategoryServices : ICategoryServices
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

    //public async Task<IEnumerable<Category>> GetAllWithMountAsync(DateTime mount)
    //{
    //    return await _context.Categories
    //        .Where(c => c.Records.Any(r => r.Date.Year == mount.Year && r.Date.Month == mount.Month))
    //        .ToListAsync();
    //}

    public async Task<IEnumerable<CategoryWithAmontDto>> GetAllWithMountAsync(DateTime mount)
    {
        var categories = await _context.Categories
            .Include(c => c.Records.Where(r => r.Date.Year == mount.Year && r.Date.Month == mount.Month))
            .ToListAsync();
        return _mapper.Map<List<CategoryWithAmontDto>>(categories);
    }

    public async Task<Category> GetByIdWithMountAsync(int id,DateTime date)
    {
        if(await _context.Categories.Include(r=>r.Records.Where(r=>r.Date.Year==date.Year && r.Date.Month==date.Month)).FirstOrDefaultAsync(c=>c.Id==id) is Category data)
        {
            return data;
        }
        throw new Exception("Not found Category");
    }
    
    public async Task<Category> GetByIdAsync(int id)
    {
        if(await _context.Categories.FindAsync(id) is Category data)
        {
            return data;
        }
        throw new Exception("Not found Category");
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        if (await _context.Categories.FindAsync(category.Id) is Category find)
        {
            _context.Categories.Entry(find).State = EntityState.Detached;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return;
        }

        throw new Exception($"Error update:{typeof(Category)}- Id={category.Id}");
    }

    public async Task DeleteAsync(int id)
    {
        if (await _context.Categories.FindAsync(id) is Category find)
        {
            _context.Categories.Remove(find);
            await _context.SaveChangesAsync();
            return;
        }

        throw new Exception($"Error remove:{typeof(Category)} - Id={id}");
    }
}