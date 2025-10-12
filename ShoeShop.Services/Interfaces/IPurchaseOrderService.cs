using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs; // This using statement is now correct

namespace ShoeShop.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderDto>> GetAllPurchaseOrdersAsync();
        Task<PurchaseOrderDto?> GetByIdAsync(int id);
        Task<PurchaseOrder> CreatePurchaseOrderAsync(CreatePurchaseOrderDto purchaseOrder);
        Task UpdateAsync(PurchaseOrder purchaseOrder);
        Task DeleteAsync(int id);
    }
}