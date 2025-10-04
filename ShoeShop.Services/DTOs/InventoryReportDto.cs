<<<<<<< HEAD
﻿// SA InventoryReportDto.cs FILE
namespace ShoeShop.Services.DTOs
{
    public class InventoryReportDto
    {
        public decimal TotalStockValue { get; set; } // Fixes CS0117
        public int LowStockCount { get; set; }       // Fixes CS0117
        public int TotalPullOutsPending { get; set; } // Fixes CS0117
=======
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
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
    }
}