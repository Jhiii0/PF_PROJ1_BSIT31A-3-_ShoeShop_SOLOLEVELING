using System.Threading.Tasks;
using System;
using ShoeShop.Services.DTOs;


namespace ShoeShop.Services.Interfaces
{
    public interface IReportService
    {
        // Fixes CS0246 errors
        Task<IEnumerable<StockPullOutDto>> GetPullOutReportAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int count);
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
    }
}