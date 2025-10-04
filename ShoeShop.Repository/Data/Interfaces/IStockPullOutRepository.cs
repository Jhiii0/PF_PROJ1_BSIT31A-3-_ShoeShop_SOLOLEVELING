using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IStockPullOutRepository
    {
        Task AddAsync(StockPullOut pullOut);
        Task<IEnumerable<StockPullOut>> GetAllAsync(); // optional basic list
        Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync(); // used in InventoryService
        Task<StockPullOut?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
