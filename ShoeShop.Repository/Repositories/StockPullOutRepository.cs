using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class StockPullOutRepository : IStockPullOutRepository
    {
        private readonly ApplicationDbContext _context;

        public StockPullOutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockPullOut>> GetAllAsync()
        {
            return await _context.StockPullOuts
                                 .Include(p => p.ShoeColorVariation)
                                 .ThenInclude(v => v.Shoe)
                                 .ToListAsync();
        }

        public async Task<StockPullOut?> GetByIdAsync(int id)
        {
            return await _context.StockPullOuts
                                 .Include(p => p.ShoeColorVariation)
                                 .ThenInclude(v => v.Shoe)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(StockPullOut entity)
        {
            await _context.StockPullOuts.AddAsync(entity);
        }

        public async Task DeleteAsync(StockPullOut entity)
        {
            _context.StockPullOuts.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync()
        {
            return await _context.StockPullOuts
                                 .Include(p => p.ShoeColorVariation)
                                 .ThenInclude(v => v.Shoe)
                                 .ToListAsync();
        }

    }
}
