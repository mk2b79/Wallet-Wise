using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.BLL.DTOs;

public class RecordsHistoryDto
{
    public CategoryWithAmontDto Category { get; set; }
    public IEnumerable<RecordDto> RecordHistory { get; set; }
}