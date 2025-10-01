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
        private readonly ShoeShopDbContext _context;

        public ShoeRepository(ShoeShopDbContext context)
        {
            _context = context;
        }

        // Helper method para isama ang ColorVariations
        private IQueryable<Shoe> GetShoeQuery()
        {
            return _context.Shoes.Include(s => s.ColorVariations);
        }

        // DITO ANG FIX: Inayos ang return type para maging nullable (Task<Shoe?>)
        public async Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId)
        {
            // Ang logic ay hahanapin ang parent Shoe kung ang ID ng ColorVariation ay tugma
            return await GetShoeQuery()
                .FirstOrDefaultAsync(s => s.ColorVariations.Any(v => v.Id == colorVariationId));
        }

        // MISSING METHOD FIX: Ibinalik ang GetShoeByIdAsync na may tamang nullable return type
        public async Task<Shoe?> GetShoeByIdAsync(int id)
        {
            // Kukunin ang shoe kasama ang color variations
            return await GetShoeQuery().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
        {
            // Kukunin ang lahat ng shoes kasama ang color variations
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
            // I-update lang ang status at mag-save ng changes
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
    }
}