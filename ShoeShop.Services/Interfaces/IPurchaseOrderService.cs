<<<<<<< HEAD
﻿using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    // Interface para sa Purchase Order operations
    public interface IPurchaseOrderService
    {
        // Sample method para sa paggawa ng purchase order.
        // Palitan ang 'object' ng tamang DTO o entity na gagamitin mo.
        Task<bool> CreatePurchaseOrderAsync(object orderDetails);
=======
﻿using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderDto> CreateOrderAsync(CreatePurchaseOrderDto orderDto);
        Task<PurchaseOrderDto> ReceiveOrderAsync(int orderId, int shoeColorVariationId, int quantityReceived);
        Task<IEnumerable<PurchaseOrderDto>> GetOrderHistoryAsync();
        Task<PurchaseOrderDto> GetOrderByIdAsync(int orderId);

        // Supplier management methods
        Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto);
>>>>>>> origin/memberC
    }
}
