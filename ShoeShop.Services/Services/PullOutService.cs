<<<<<<< HEAD
﻿using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
=======
<<<<<<< HEAD
﻿using AutoMapper;
using ShoeShop.Repository.Interfaces; // <-- Tiyakin na TAMA ang reference at namespace na ito (CS0246)
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System; // Kailangan para sa InvalidOperationException
using System.Collections.Generic;
using System.Linq; // Kailangan para sa .Where(p => p.Status == "Pending")
=======
<<<<<<< HEAD
﻿using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
=======
﻿using ShoeShop.Services.DTOs;
>>>>>>> origin/memberC
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
<<<<<<< HEAD
=======
<<<<<<< HEAD
    public class PullOutService : IPullOutService
    {
        private readonly IStockPullOutRepository _pullOutRepository; // Line 10: Tiyakin na may Project Reference sa Repository
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public PullOutService(IStockPullOutRepository pullOutRepository, IInventoryService inventoryService, IMapper mapper) // Line 14: Constructor
        {
            _pullOutRepository = pullOutRepository;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        public async Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto pullOutDto)
        {
            // Line 23: Naka-fix na ang GetStockQuantityAsync error dahil sa updated IInventoryService
            var currentStock = await _inventoryService.GetStockQuantityAsync(pullOutDto.ShoeColorVariationId);
            if (currentStock < pullOutDto.Quantity)
            {
                throw new InvalidOperationException("Requested pull-out quantity exceeds current stock.");
            }

            var pullOut = _mapper.Map<ShoeShop.Repository.Entities.StockPullOut>(pullOutDto);
            pullOut.PullOutDate = DateTime.UtcNow;
            pullOut.Status = "Pending";

            // Example Business Rule: Small quantities are auto-approved
            if (pullOut.Quantity < 5)
            {
                pullOut.Status = "Approved";
                pullOut.ApprovedBy = "System (Auto)";

                // Line 40: Naka-fix na ang AdjustStockAsync error dahil sa updated IInventoryService
                // (Ngayon ay tumatanggap na ng 4 arguments: ID, Quantity, Reason, AdjustedBy)
                await _inventoryService.AdjustStockAsync(
                    pullOut.ShoeColorVariationId,
                    -pullOut.Quantity,
                    pullOut.Reason,
                    pullOut.RequestedBy); // AdjustedBy argument
            }

            var createdPullOut = await _pullOutRepository.AddPullOutAsync(pullOut);
            return _mapper.Map<PullOutRequestDto>(createdPullOut);
        }

        public async Task<bool> ApprovePullOutAsync(int pullOutId, string managerId)
        {
            var pullOut = await _pullOutRepository.GetPullOutByIdAsync(pullOutId);
            if (pullOut == null || pullOut.Status != "Pending")
            {
                return false;
            }

            // Line 59: Naka-fix na ang GetStockQuantityAsync error
            var currentStock = await _inventoryService.GetStockQuantityAsync(pullOut.ShoeColorVariationId);
            if (currentStock < pullOut.Quantity)
            {
                throw new InvalidOperationException("Stock depleted before approval. Cannot approve.");
            }

            pullOut.Status = "Approved";
            pullOut.ApprovedBy = managerId;

            // Adjust stock only if not auto-approved already
            if (pullOut.ApprovedBy != "System (Auto)")
            {
                await _inventoryService.AdjustStockAsync(
                    pullOut.ShoeColorVariationId,
                    -pullOut.Quantity,
                    pullOut.Reason,
                    managerId); // AdjustedBy argument
            }

            await _pullOutRepository.UpdatePullOutAsync(pullOut);
            return true;
        }

        public async Task<bool> RejectPullOutAsync(int pullOutId)
        {
            var pullOut = await _pullOutRepository.GetPullOutByIdAsync(pullOutId);
            if (pullOut == null || pullOut.Status != "Pending")
            {
                return false;
            }
            pullOut.Status = "Rejected";
            await _pullOutRepository.UpdatePullOutAsync(pullOut);
            return true;
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
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
<<<<<<< HEAD
        }
    }
}
=======
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
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        }

        public async Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync()
        {
<<<<<<< HEAD
            var pending = await _pullOutRepository.GetAllPullOutsAsync();
            var pendingList = pending.Where(p => p.Status == "Pending").ToList();
            return _mapper.Map<IEnumerable<PullOutRequestDto>>(pendingList);
=======
            return await Task.FromResult(new List<PullOutRequestDto>());
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        }

        public async Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync()
        {
<<<<<<< HEAD
            var history = await _pullOutRepository.GetAllPullOutsAsync();
            return _mapper.Map<IEnumerable<PullOutRequestDto>>(history);
        }
    }
}
=======
            return await Task.FromResult(new List<PullOutRequestDto>());
>>>>>>> origin/memberC
        }
    }
}
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
