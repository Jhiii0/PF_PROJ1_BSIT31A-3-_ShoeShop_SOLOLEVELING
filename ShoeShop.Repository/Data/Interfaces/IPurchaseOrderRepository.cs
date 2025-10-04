using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        // 1. Missing Method: AddOrderAsync (ginagamit sa CreateOrderAsync)
        Task<PurchaseOrder> AddOrderAsync(PurchaseOrder order);

        // 2. Missing Method: GetOrderByIdAsync (ginagamit sa ReceiveOrderAsync at GetOrderByIdAsync)
        Task<PurchaseOrder?> GetOrderByIdAsync(int orderId);

        // 3. Missing Method: UpdateOrderAsync (ginagamit sa ReceiveOrderAsync)
        Task UpdateOrderAsync(PurchaseOrder order);

        // 4. Missing Method: GetAllOrdersAsync (ginagamit sa GetOrderHistoryAsync)
        Task<IEnumerable<PurchaseOrder>> GetAllOrdersAsync();

        // ... (Iba pang methods kung mayroon man)
    }
}