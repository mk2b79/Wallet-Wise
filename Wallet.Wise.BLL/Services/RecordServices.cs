using Wallet.Wise.BLL.Services.IServices;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services;

public class RecordServices:IRecordServices
{
    public Task<IEnumerable<Record>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Record> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Record record)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Record record)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}