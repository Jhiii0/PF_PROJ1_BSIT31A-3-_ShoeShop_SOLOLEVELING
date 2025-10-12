using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.AsNoTracking().ToListAsync();
        }

        // ITO ANG INAYOS NA METHOD:
        // Ang return type ay ginawa nang "async Task<Supplier>" para tumugma sa interface.
        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier; // Idinagdag ang pag-return ng supplier object.
        }

        // Ang mga ito ay hindi pa natin kailangan sa ngayon.
        public Task<IEnumerable<Supplier>> GetAllSuppliersAsync() => throw new System.NotImplementedException();
        public Task<Supplier?> GetSupplierByIdAsync(int supplierId) => throw new System.NotImplementedException();
    }
}