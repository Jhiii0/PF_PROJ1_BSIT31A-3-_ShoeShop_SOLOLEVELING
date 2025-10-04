using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq; // Kailangan ito para sa .Any() at iba pa
=======
using System.Linq;
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
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

<<<<<<< HEAD
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
=======
        // Helper method para isama ang ColorVariations
        private IQueryable<Shoe> GetShoeQuery()
<<<<<<< HEAD
        {
            return _context.Shoes.Include(s => s.ColorVariations);
=======
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
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        }

        // 1. ADD METHOD: Tamang AddAsync implementation
        public async Task AddAsync(Shoe entity)
        {
<<<<<<< HEAD
            // Gumamit ng GetShoeQuery para sa includes
            return await GetShoeQuery().ToListAsync();
=======
<<<<<<< HEAD
            await _context.Shoes.AddAsync(entity);
=======
            // Kukunin ang lahat ng shoes kasama ang color variations
            return await GetShoeQuery().ToListAsync();
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        }

        // 2. UPDATE METHOD: Tamang UpdateAsync implementation
        public Task UpdateAsync(Shoe entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask; // Hindi na kailangan ng await Task.CompletedTask
        }

        // 3. GET ALL with VARIATIONS (MISSING IMPLEMENTATION): Ginagamit ang logic ng dating GetAllShoesAsync
        public async Task<IEnumerable<Shoe>> GetAllWithVariationsAsync()
        {
<<<<<<< HEAD
            // Hindi na kailangan i-fetch muna, direkta na ang update sa entity
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
=======
            return await GetShoeQuery().ToListAsync();
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        }

        // 4. GET BY ID with VARIATIONS (MISSING IMPLEMENTATION): Ginagamit ang logic ng dating GetShoeByIdAsync
        public async Task<Shoe?> GetByIdWithVariationsAsync(int id)
        {
            return await GetShoeQuery().FirstOrDefaultAsync(s => s.Id == id);
        }

        // 5. DELETE ASYNC (MISSING IMPLEMENTATION): Kinakailangan ang Shoe object bilang parameter (galing sa CS0535)
        public async Task DeleteAsync(Shoe shoe)
        {
            // Assuming the entity passed is tracked or fetched already.
            _context.Shoes.Remove(shoe);
            await Task.CompletedTask; // Returns a completed task since SaveChangesAsync will do the work.
        }

        // Ginamit mo ang DeleteAsync(int id) na may logic, kaya idadagdag natin siya
        // sa class mo. (Pero TANGGALIN mo siya sa IShoeRepository kung DeleteAsync(Shoe) lang ang kailangan)
        public async Task DeleteAsync(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
            }
        }

<<<<<<< HEAD
        // ITO ANG MISSING METHOD IMPLEMENTATION (Inaayos ang CS0535 error)
        public async Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId)
        {
            // Hahanapin ang parent Shoe kung ang colorVariationId ay tugma sa alinman sa kanyang variations.
=======
        // 6. SAVE CHANGES: Inayos ang return type para maging Task<int>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // --- Iba pang Methods na Ginagamit Mo (Optional, depende sa interface) ---

        // Ginagamit ang GetByIdWithVariationsAsync sa taas
        // public async Task<Shoe?> GetShoeByIdAsync(int id) { ... } 

        // Ginagamit ang GetAllWithVariationsAsync sa taas
        // public async Task<IEnumerable<Shoe>> GetAllShoesAsync() { ... }

        public async Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId)
        {
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
            return await GetShoeQuery()
                .FirstOrDefaultAsync(s => s.ColorVariations.Any(v => v.Id == colorVariationId));
        }
    }
}