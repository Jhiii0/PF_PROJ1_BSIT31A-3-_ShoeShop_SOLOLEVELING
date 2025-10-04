using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IStockPullOutRepository
    {
        Task<StockPullOut> AddPullOutAsync(StockPullOut pullOut);
        Task<StockPullOut?> GetPullOutByIdAsync(int pullOutId);
        Task UpdatePullOutAsync(StockPullOut pullOut);
        Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync();
    }
}