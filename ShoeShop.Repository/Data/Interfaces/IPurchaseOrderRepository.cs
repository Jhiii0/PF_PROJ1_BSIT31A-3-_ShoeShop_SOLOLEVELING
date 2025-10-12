using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// The namespace has been corrected for consistency
namespace ShoeShop.Repository.Data.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder?> GetByIdAsync(int id);

        // The method has been renamed from CreateAsync to AddAsync to fix the error
        Task AddAsync(PurchaseOrder purchaseOrder);

        Task UpdateAsync(PurchaseOrder purchaseOrder);
        Task DeleteAsync(int id);
    }
}