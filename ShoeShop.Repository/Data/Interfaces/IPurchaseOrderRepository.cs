using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder?> GetByIdAsync(int id);
        Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder);
        Task UpdateAsync(PurchaseOrder purchaseOrder);
        Task DeleteAsync(int id);
    }
}
