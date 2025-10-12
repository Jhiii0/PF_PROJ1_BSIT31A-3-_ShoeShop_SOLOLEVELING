using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            
            return await _context.PurchaseOrders
                                 .Include(po => po.Supplier)
                                 .Include(po => po.Items)
                                     
                                     .ThenInclude(item => item.ShoeColorVariation)
                                    
                                     .ThenInclude(scv => scv.Shoe)
                                 .ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders
                                 .Include(po => po.Supplier)
                                 .Include(po => po.Items)
                                     .ThenInclude(item => item.ShoeColorVariation)
                                     .ThenInclude(scv => scv.Shoe)
                                 .FirstOrDefaultAsync(po => po.Id == id);
        }

        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
        }

        public Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Update(purchaseOrder);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var purchaseOrder = await GetByIdAsync(id);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
            }
        }
    }
}