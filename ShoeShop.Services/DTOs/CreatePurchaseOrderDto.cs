using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Add this using statement

namespace ShoeShop.Services.DTOs
{
    public class CreatePurchaseOrderDto
    {
        // This validation attribute ensures a valid supplier is selected
        [Range(1, int.MaxValue, ErrorMessage = "The Supplier field is required.")]
        public int SupplierId { get; set; }

        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }

    public class PurchaseOrderItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select a shoe.")]
        public int ShoeId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0.")]
        public decimal UnitPrice { get; set; }
    }
}