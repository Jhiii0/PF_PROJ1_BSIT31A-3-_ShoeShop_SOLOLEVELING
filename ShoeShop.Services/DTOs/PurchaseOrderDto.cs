using System;

namespace ShoeShop.Services.DTOs
{
    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public string? SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}