using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq; // Kailangan ito para sa .Any() at iba pa
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoeShopDbContext _context;

        public ShoeRepository(ShoeShopDbContext context)
        {
            _context = context;
        }

        // --- Helper method for common includes ---
        private IQueryable<Shoe> GetShoeQuery()
        {
            return _context.Shoes.Include(s => s.ColorVariations);
        }

        // --- Core Repository Methods ---

        public async Task<Shoe?> GetShoeByIdAsync(int id)
        {
            // Gumamit ng GetShoeQuery para sa includes
            return await GetShoeQuery().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
        {
            // Gumamit ng GetShoeQuery para sa includes
            return await GetShoeQuery().ToListAsync();
        }

        public async Task<Shoe> AddShoeAsync(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task UpdateShoeAsync(Shoe shoe)
        {
            // Hindi na kailangan i-fetch muna, direkta na ang update sa entity
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoeAsync(int id)
        {
            var shoeToDelete = await _context.Shoes.FindAsync(id);
            if (shoeToDelete != null)
            {
                _context.Shoes.Remove(shoeToDelete);
                await _context.SaveChangesAsync();
            }
        }

        // ITO ANG MISSING METHOD IMPLEMENTATION (Inaayos ang CS0535 error)
        public async Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId)
        {
            // Hahanapin ang parent Shoe kung ang colorVariationId ay tugma sa alinman sa kanyang variations.
            return await GetShoeQuery()
                .FirstOrDefaultAsync(s => s.ColorVariations.Any(v => v.Id == colorVariationId));
        }
    }
}