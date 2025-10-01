using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
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
        }
    }
}
