using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ShoeShop.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        // Tandaan: Kung kailangan mo ng IInventoryRepository, idagdag ito sa constructor
        public ReportService(IStockPullOutRepository pullOutRepository, IMapper mapper)
        {
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        // 1. ORIGINAL METHOD (Pull Out Report)
        public async Task<IEnumerable<StockPullOutDto>> GetPullOutReportAsync(DateTime startDate, DateTime endDate)
        {
            var allPullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            var filteredPullOuts = allPullOuts
                .Where(p => p.PullOutDate >= startDate && p.PullOutDate <= endDate)
                .ToList();

            return _mapper.Map<IEnumerable<StockPullOutDto>>(filteredPullOuts);
        }

        // 2. MISSING METHOD (Recent Pull Outs)
        public async Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int count)
        {
            var recentPullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            var latest = recentPullOuts
                .OrderByDescending(p => p.PullOutDate)
                .Take(count)
                .ToList();

            return _mapper.Map<IEnumerable<StockPullOutDto>>(latest);
        }

        // 3. CORRECTED IMPLEMENTATION (Inaayos ang CS0738 error)
        // SIGNATURE: Pinalitan ang return type mula Task<Dictionary<string, object>> sa Task<InventoryReportDto>
        public async Task<InventoryReportDto> GetInventoryDashboardReportAsync()
        {
            // Placeholder: Dapat dito ang logic mo para kumuha ng Inventory at Pull Out metrics
            await Task.CompletedTask;

            // Tiyakin na ang method ay nagbabalik ng InventoryReportDto instance
            return new InventoryReportDto
            {
                // Kailangan mo itong punan ng totoong data base sa logic mo
                TotalStockValue = 0.00m,
                LowStockCount = 0,
                TotalPullOutsPending = 0
            };
        }
    }
}