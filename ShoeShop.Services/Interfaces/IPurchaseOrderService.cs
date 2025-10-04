<<<<<<< HEAD
=======
<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
﻿using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    // Interface para sa Purchase Order operations
    public interface IPurchaseOrderService
    {
        // Sample method para sa paggawa ng purchase order.
        // Palitan ang 'object' ng tamang DTO o entity na gagamitin mo.
        Task<bool> CreatePurchaseOrderAsync(object orderDetails);
<<<<<<< HEAD
=======
=======
﻿using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a

namespace ShoeShop.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderDto> CreateOrderAsync(CreatePurchaseOrderDto orderDto);
        Task<PurchaseOrderDto> ReceiveOrderAsync(int orderId, int shoeColorVariationId, int quantityReceived);
        Task<IEnumerable<PurchaseOrderDto>> GetOrderHistoryAsync();
        Task<PurchaseOrderDto> GetOrderByIdAsync(int orderId);
<<<<<<< HEAD
        Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto);
=======

        // Supplier management methods
        Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto);
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
    }
}
