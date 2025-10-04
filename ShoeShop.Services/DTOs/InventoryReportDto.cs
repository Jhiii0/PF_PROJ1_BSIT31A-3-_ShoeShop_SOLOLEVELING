<<<<<<< HEAD
﻿namespace ShoeShop.Services.DTOs
{
    public class InventoryReportDto
    {
        public int ShoeId { get; set; }
        public string ShoeName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int TotalStock { get; set; }
=======
﻿// FILE: ShoeShop.Services\DTOs\InventoryReportDto.cs

namespace ShoeShop.Services.DTOs
{
    // Fixes CS0117 errors sa ReportService
    public class InventoryReportDto
    {
        public decimal TotalStockValue { get; set; }
        public int LowStockCount { get; set; }
        public int TotalPullOutsPending { get; set; }
>>>>>>> origin/memberC
    }
}