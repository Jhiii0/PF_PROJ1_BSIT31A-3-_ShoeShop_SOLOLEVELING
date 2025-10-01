using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderDto> CreateOrderAsync(CreatePurchaseOrderDto orderDto);
        Task<PurchaseOrderDto> ReceiveOrderAsync(int orderId, int shoeColorVariationId, int quantityReceived);
        Task<IEnumerable<PurchaseOrderDto>> GetOrderHistoryAsync();
        Task<PurchaseOrderDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto);
    }
}
