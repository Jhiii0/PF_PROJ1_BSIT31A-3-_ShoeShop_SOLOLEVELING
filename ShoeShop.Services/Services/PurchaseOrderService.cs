using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.Interfaces;

namespace ShoeShop.Services.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;

        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder)
        {
            return await _repository.CreateAsync(purchaseOrder);
        }

        public async Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            await _repository.UpdateAsync(purchaseOrder);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
