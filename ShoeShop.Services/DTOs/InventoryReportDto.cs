// SA InventoryReportDto.cs FILE
namespace ShoeShop.Services.DTOs
{
    public class InventoryReportDto
    {
        public decimal TotalStockValue { get; set; } // Fixes CS0117
        public int LowStockCount { get; set; }       // Fixes CS0117
        public int TotalPullOutsPending { get; set; } // Fixes CS0117
    }
}