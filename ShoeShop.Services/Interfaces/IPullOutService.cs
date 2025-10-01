using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IPullOutService
    {
        Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto pullOutDto);
        Task<bool> ApprovePullOutAsync(int pullOutId, string managerId);
        Task<bool> RejectPullOutAsync(int pullOutId);
        Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync();
        Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync();
    }
}