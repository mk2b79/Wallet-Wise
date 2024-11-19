using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.Services.IServices;

public interface IRecordServices
{
    Task<IEnumerable<Record>> GetAllAsync();
    Task<Record> GetByIdAsync(int id);
    Task AddAsync(Record record);
    Task UpdateAsync(Record record);
    Task DeleteAsync(int id);
}