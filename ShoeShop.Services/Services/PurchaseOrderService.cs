<<<<<<< HEAD
=======
<<<<<<< HEAD
﻿using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
﻿using ShoeShop.Services.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
// Maaaring kailangan mo pa ng iba pang using directives dito (e.g., para sa DTOs o Repositories)

namespace ShoeShop.Services.Services
{
    // Implementation ng Purchase Order Service
    public class PurchaseOrderService : IPurchaseOrderService
    {
        // Kung kailangan mo ng repository o iba pang serbisyo, dito mo idadagdag.
        // private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        // Constructor
        public PurchaseOrderService(/* IPurchaseOrderRepository purchaseOrderRepository */)
        {
            // _purchaseOrderRepository = purchaseOrderRepository;
        }

        // Ito ang method na kinakailangan ng IPurchaseOrderService
        public Task<bool> CreatePurchaseOrderAsync(object orderDetails)
        {
            // Dito mo ilalagay ang actual logic:
            // 1. Validate ang orderDetails.
            // 2. I-save ang Purchase Order sa database gamit ang repository.
            // 3. I-update ang stock levels (kung kinakailangan).

            // Sa ngayon, magre-return lang tayo ng true para mag-compile ang solution.
            return Task.FromResult(true);
        }
    }
}
<<<<<<< HEAD
=======
=======
﻿// SA ShoeShop.Services\Services\PurchaseOrderService.cs FILE:

// Tiyakin na kumpleto ang using statements
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.DTOs;
// ... (Iba pang using statements) ...
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a

namespace ShoeShop.Services.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
<<<<<<< HEAD
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public PurchaseOrderService(
            IPurchaseOrderRepository orderRepository,
            ISupplierRepository supplierRepository,
            IInventoryService inventoryService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        public async Task<PurchaseOrderDto> CreateOrderAsync(CreatePurchaseOrderDto orderDto)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(orderDto.SupplierId);
            if (supplier == null)
            {
                throw new InvalidOperationException("Supplier not found.");
            }

            var order = _mapper.Map<ShoeShop.Repository.Entities.PurchaseOrder>(orderDto);
            order.OrderDate = DateTime.UtcNow;
            order.Status = "Pending";

            // Calculate Total Amount based on unit costs
            order.TotalAmount = order.Items.Sum(i => i.QuantityOrdered * i.UnitCost);

            var createdOrder = await _orderRepository.AddOrderAsync(order);
            return _mapper.Map<PurchaseOrderDto>(createdOrder);
        }

        public async Task<PurchaseOrderDto> ReceiveOrderAsync(int orderId, int shoeColorVariationId, int quantityReceived)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status == "Received" || order.Status == "Cancelled")
            {
                throw new InvalidOperationException("Order cannot be received.");
            }

            var item = order.Items.FirstOrDefault(i => i.ShoeColorVariationId == shoeColorVariationId);
            if (item == null)
            {
                throw new InvalidOperationException("Item not part of this order.");
            }

            // Business Logic: Check if received quantity is valid
            if (quantityReceived > item.QuantityOrdered - item.QuantityReceived)
            {
                throw new InvalidOperationException("Received quantity exceeds quantity ordered.");
            }

            item.QuantityReceived += quantityReceived;

            // Adjust stock (Add stock)
            await _inventoryService.AdjustStockAsync(
                item.ShoeColorVariationId,
                quantityReceived,
                $"Received PO #{order.OrderNumber}",
                "System");

            // Check if the whole order is received
            if (order.Items.All(i => i.QuantityOrdered == i.QuantityReceived))
            {
                order.Status = "Received";
            }

            await _orderRepository.UpdateOrderAsync(order);
            return _mapper.Map<PurchaseOrderDto>(order);
        }

        public async Task<IEnumerable<PurchaseOrderDto>> GetOrderHistoryAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<PurchaseOrderDto>>(orders);
        }

        public async Task<PurchaseOrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return _mapper.Map<PurchaseOrderDto>(order);
        }

        public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<ShoeShop.Repository.Entities.Supplier>(supplierDto);
            var createdSupplier = await _supplierRepository.AddSupplierAsync(supplier);
            return _mapper.Map<SupplierDto>(createdSupplier);
        }
    }
}
=======
        // Constructor at fields dito...

        // FINAL FIX: Idagdag ang mga method na ito (kahit walang laman pa)
        public async Task<PurchaseOrderDto> CreateOrderAsync(CreatePurchaseOrderDto orderDto) { /* Implement logic */ throw new NotImplementedException(); }
        public async Task<PurchaseOrderDto> ReceiveOrderAsync(int orderId, int shoeColorVariationId, int quantityReceived) { throw new NotImplementedException(); }
        public async Task<IEnumerable<PurchaseOrderDto>> GetOrderHistoryAsync() { throw new NotImplementedException(); }
        public async Task<PurchaseOrderDto> GetOrderByIdAsync(int orderId) { throw new NotImplementedException(); }
        public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync() { throw new NotImplementedException(); }
        public async Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto) { throw new NotImplementedException(); }
    }
}
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
