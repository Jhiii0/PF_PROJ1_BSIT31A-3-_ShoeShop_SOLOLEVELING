// FILE: ShoeShop.Services\DTOs\InventoryReportDto.cs

namespace ShoeShop.Services.DTOs
{
    // Fixes CS0117 errors sa ReportService
    public class InventoryReportDto
    {
        public decimal TotalStockValue { get; set; }
        public int LowStockCount { get; set; }
        public int TotalPullOutsPending { get; set; }
    }
}