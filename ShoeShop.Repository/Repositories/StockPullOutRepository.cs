using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data; // Assuming ito ang lokasyon ng iyong DbContext
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    // FINAL FIX: Tiyakin na public ang class declaration
    public class StockPullOutRepository : IStockPullOutRepository
    {
        private readonly ShoeShopDbContext _context; // Assuming ShoeShopDbContext ang pangalan

        public StockPullOutRepository(ShoeShopDbContext context)
        {
            _context = context;
        }

        public async Task<StockPullOut> AddPullOutAsync(StockPullOut pullOut)
        {
            _context.StockPullOuts.Add(pullOut);
            await _context.SaveChangesAsync();
            return pullOut;
        }

        public async Task<StockPullOut?> GetPullOutByIdAsync(int pullOutId)
        {
            // Kasama ang ColorVariation para sa reporting/validation
            return await _context.StockPullOuts
                .FirstOrDefaultAsync(p => p.Id == pullOutId);
        }

        public async Task UpdatePullOutAsync(StockPullOut pullOut)
        {
            _context.StockPullOuts.Update(pullOut);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync()
        {
            // Kukunin lahat ng pull-out requests
            return await _context.StockPullOuts
                .OrderByDescending(p => p.PullOutDate)
                .ToListAsync();
        }
    }
}