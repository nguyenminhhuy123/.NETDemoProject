using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface IReceiptsRepository
    {
        Task<ICollection<Receipt>> GetReceipts(); 

        bool PostReceipt(Receipt receipt);

        bool PutReceipt(Receipt receipt);

        Receipt GetReceiptById(int id);

        bool IsExist(int id);

        bool DeleteReceipt(Receipt receipt);

        bool SaveChanges(); 
    }
}