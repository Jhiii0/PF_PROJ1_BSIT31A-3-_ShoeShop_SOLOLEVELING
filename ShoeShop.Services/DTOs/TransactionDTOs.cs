using System.Collections.Generic;
using System;

// FILE: ShoeShop.Services\DTOs\TransactionDTOs.cs

namespace ShoeShop.Services.DTOs
{
    // --- Pull Out DTOs ---
    public class PullOutRequestDto
    {
        public int Id { get; set; }
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PullOutDate { get; set; }
    }

    public class CreatePullOutDto // FIX: Ito ang missing class mo!
    {
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
    }

    // --- Purchase Order DTOs ---
    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
    }

    public class CreatePurchaseOrderDto
    {
        public int SupplierId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public List<CreatePurchaseOrderItemDto> Items { get; set; } = new List<CreatePurchaseOrderItemDto>();
    }

    public class PurchaseOrderItemDto
    {
        public int ShoeColorVariationId { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public decimal UnitCost { get; set; }
    }

    public class CreatePurchaseOrderItemDto
    {
        public int ShoeColorVariationId { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal UnitCost { get; set; }
    }

    // --- Supplier DTO ---
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
    }
}