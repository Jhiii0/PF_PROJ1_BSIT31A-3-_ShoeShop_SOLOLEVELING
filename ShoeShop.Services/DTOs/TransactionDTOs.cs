<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Services.DTOs
{
    // --- SUPPLIER DTO ---
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }

    // --- PURCHASE ORDER DTOs ---
    public class CreatePurchaseOrderDto
    {
        [Required(ErrorMessage = "Order Number is required.")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Supplier must be selected.")]
        public int SupplierId { get; set; }

        public DateTime ExpectedDate { get; set; }

        [MinLength(1, ErrorMessage = "At least one item must be ordered.")]
        public List<CreatePurchaseOrderItemDto> Items { get; set; } = new List<CreatePurchaseOrderItemDto>();
    }

    public class CreatePurchaseOrderItemDto
    {
        [Required]
        public int ShoeColorVariationId { get; set; }

        [Range(1, 10000, ErrorMessage = "Quantity must be greater than zero.")]
        public int QuantityOrdered { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Unit Cost must be provided.")]
        public decimal UnitCost { get; set; }
    }

    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public SupplierDto Supplier { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Status { get; set; }
=======
﻿using System.Collections.Generic;
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
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
    }

<<<<<<< HEAD
    public class PurchaseOrderItemDto
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public ShoeColorVariationDto ShoeColorVariation { get; set; }
=======
    public class CreatePurchaseOrderDto
    {
        public int SupplierId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public List<CreatePurchaseOrderItemDto> Items { get; set; } = new List<CreatePurchaseOrderItemDto>();
    }

    public class PurchaseOrderItemDto
    {
        public int ShoeColorVariationId { get; set; }
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public decimal UnitCost { get; set; }
    }

<<<<<<< HEAD
    // --- PULL-OUT DTOs ---
    public class CreatePullOutDto
    {
        [Required(ErrorMessage = "Shoe Color Variation is required.")]
        public int ShoeColorVariationId { get; set; }

        [Range(1, 10000, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Reason for pull out is required.")]
        public string Reason { get; set; }

        public string? ReasonDetails { get; set; }

        [Required(ErrorMessage = "Requesting staff name is required.")]
        public string RequestedBy { get; set; }
    }

    public class PullOutRequestDto
    {
        public int Id { get; set; }
        public int ShoeColorVariationId { get; set; }
        public string ShoeName { get; set; }
        public string ColorName { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public string RequestedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime PullOutDate { get; set; }
        public string Status { get; set; }
    }

}
=======
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
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
