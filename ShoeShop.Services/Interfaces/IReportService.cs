using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Interfaces
{
    public interface IReportService
    {
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int take = 10);
    }
}
