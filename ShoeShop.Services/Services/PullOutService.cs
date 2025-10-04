<<<<<<< HEAD
﻿using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
=======
﻿using ShoeShop.Services.DTOs;
>>>>>>> origin/memberC
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
<<<<<<< HEAD
    // Implementation ng Pull Out Service
    public class PullOutService : IPullOutService
    {
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        // Constructor para sa Dependency Injection
        public PullOutService(IStockPullOutRepository pullOutRepository, IMapper mapper)
        {
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockPullOutDto>> GetAllPullOutsAsync()
        {
            // Kukunin ang lahat ng pull out entities mula sa repository
            var pullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            // I-ma-map ang entities sa DTOs bago i-return
            return _mapper.Map<IEnumerable<StockPullOutDto>>(pullOuts);
=======
    public class PullOutService : IPullOutService
    {
        public async Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto dto)
        {
            return await Task.FromResult(new PullOutRequestDto());
        }

        public async Task<PullOutRequestDto> ApprovePullOutAsync(int requestId, string approvedBy)
        {
            return await Task.FromResult(new PullOutRequestDto());
        }

        public async Task<PullOutRequestDto> RejectPullOutAsync(int requestId, string reason)
        {
            return await Task.FromResult(new PullOutRequestDto());
        }

        public async Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync()
        {
            return await Task.FromResult(new List<PullOutRequestDto>());
        }

        public async Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync()
        {
            return await Task.FromResult(new List<PullOutRequestDto>());
>>>>>>> origin/memberC
        }
    }
}
