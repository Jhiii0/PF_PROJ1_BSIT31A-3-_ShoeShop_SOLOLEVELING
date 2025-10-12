using AutoMapper;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IShoeRepository _shoeRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IShoeRepository shoeRepository, IMapper mapper)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _shoeRepository = shoeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseOrderDto>> GetAllPurchaseOrdersAsync()
        {
            var purchaseOrders = await _purchaseOrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PurchaseOrderDto>>(purchaseOrders);
        }

        public async Task<PurchaseOrderDto?> GetByIdAsync(int id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            return _mapper.Map<PurchaseOrderDto>(purchaseOrder);
        }

        // This method now correctly implements the interface
        public async Task<PurchaseOrder> CreatePurchaseOrderAsync(CreatePurchaseOrderDto purchaseOrderDto)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDto);
            purchaseOrder.OrderDate = DateTime.UtcNow;
            purchaseOrder.TotalAmount = purchaseOrderDto.Items.Sum(i => i.Quantity * i.UnitPrice);

            foreach (var item in purchaseOrder.Items)
            {
                // Find the specific shoe variation to update its stock
                var shoeVariation = await _shoeRepository.GetColorVariationByIdAsync(item.ShoeColorVariationId);
                if (shoeVariation != null)
                {
                    shoeVariation.StockQuantity += item.QuantityOrdered; // Assuming QuantityOrdered is the correct property
                }
            }

            await _purchaseOrderRepository.AddAsync(purchaseOrder);
            await _shoeRepository.SaveChangesAsync(); // Saves all changes to the database

            return purchaseOrder;
        }

        public Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            return _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        }

        public Task DeleteAsync(int id)
        {
            return _purchaseOrderRepository.DeleteAsync(id);
        }
    }
}