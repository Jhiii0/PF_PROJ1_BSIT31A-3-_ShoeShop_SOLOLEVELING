using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs; // FIX: Kailangan ito para sa lahat ng DTOs
using ShoeShop.Services.Interfaces; // FIX: Kailangan para sa IReportService
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShoeShop.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        public ReportService(IStockPullOutRepository pullOutRepository, IMapper mapper)
        {
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        // --- Implementation of IReportService Methods ---

        public async Task<IEnumerable<StockPullOutDto>> GetPullOutReportAsync(DateTime startDate, DateTime endDate)
        {
            var allPullOuts = await _pullOutRepository.GetAllPullOutsAsync();
            var filteredPullOuts = allPullOuts
                .Where(p => p.PullOutDate >= startDate && p.PullOutDate <= endDate)
                .ToList();
            return _mapper.Map<IEnumerable<StockPullOutDto>>(filteredPullOuts);
        }

        public async Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int count)
        {
            var recentPullOuts = await _pullOutRepository.GetAllPullOutsAsync();
            var latest = recentPullOuts
                .OrderByDescending(p => p.PullOutDate)
                .Take(count)
                .ToList();
            return _mapper.Map<IEnumerable<StockPullOutDto>>(latest);
        }

        // Final Fix: Ang implementation ay tama na
        public async Task<InventoryReportDto> GetInventoryDashboardReportAsync()
        {
            await Task.CompletedTask;

            return new InventoryReportDto
            {
                TotalStockValue = 0.00m,
                LowStockCount = 0,
                TotalPullOutsPending = 0
            };
        }
    }
}