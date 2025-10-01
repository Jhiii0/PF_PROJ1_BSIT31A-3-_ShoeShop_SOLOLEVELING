using System.ComponentModel.DataAnnotations;

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
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
    }

    public class PurchaseOrderItemDto
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public ShoeColorVariationDto ShoeColorVariation { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public decimal UnitCost { get; set; }
    }

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
