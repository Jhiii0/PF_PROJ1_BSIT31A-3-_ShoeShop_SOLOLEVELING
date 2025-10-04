using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shoe>> GetAllAsync()
        {
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .ToListAsync();
        }

        public async Task<Shoe?> GetByIdAsync(int id)
        {
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Shoe shoe)
        {
            await _context.Shoes.AddAsync(shoe);
        }

        public async Task UpdateAsync(Shoe shoe)
        {
            _context.Shoes.Update(shoe);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
            await Task.CompletedTask;
        }

        // FIXED: dapat Task, hindi void
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Shoe>> GetAllWithVariationsAsync()
        {
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .ToListAsync();
        }

        public async Task<Shoe?> GetByIdWithVariationsAsync(int id)
        {
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}
