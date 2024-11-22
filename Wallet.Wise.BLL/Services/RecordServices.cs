using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Context;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class RecordServices:IRecordServices
{
    private readonly WalletWiseContext _context;
    public RecordServices(WalletWiseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Record>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Record>> GetByCategoryAndMountAsync(int categoryId, DateTime mounh)
    {
        return await _context.Records.Where(r => r.Date.Year == mounh.Year && r.Date.Month==mounh.Month && r.Category_Id == categoryId).ToListAsync();
    }

    public Task<Record> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Record record)
    {
        await _context.Records.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Record record)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        if (await _context.Records.FindAsync(id) is Record find)
        {
            _context.Records.Remove(find);
            await _context.SaveChangesAsync();
            return;
        }
        throw new Exception("Record not found");
    }
}