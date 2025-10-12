using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
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

        // Ito ang inayos na method para sa shoe dropdown
        public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
        {
            return await _context.Shoes.AsNoTracking().ToListAsync();
        }

        // --- Iba pang methods ---
        public async Task<IEnumerable<Shoe>> GetAllAsync()
        {
            return await _context.Shoes.Include(s => s.ColorVariations).ToListAsync();
        }

        public async Task<IEnumerable<Shoe>> GetAllWithVariationsAsync()
        {
            return await _context.Shoes.Include(s => s.ColorVariations).ToListAsync();
        }

        public async Task<Shoe?> GetByIdAsync(int id)
        {
            return await _context.Shoes.FindAsync(id);
        }

        public async Task<Shoe?> GetByIdWithVariationsAsync(int id)
        {
            return await _context.Shoes.Include(s => s.ColorVariations).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ShoeColorVariation?> GetColorVariationByIdAsync(int id)
        {
            return await _context.ShoeColorVariations.FindAsync(id);
        }

        public async Task AddAsync(Shoe shoe)
        {
            await _context.Shoes.AddAsync(shoe);
        }

        public Task UpdateAsync(Shoe shoe)
        {
            _context.Shoes.Update(shoe);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}