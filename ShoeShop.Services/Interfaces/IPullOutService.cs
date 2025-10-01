using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IPullOutService
    {
        Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto dto);
        Task<PullOutRequestDto> ApprovePullOutAsync(int requestId, string approvedBy);
        Task<PullOutRequestDto> RejectPullOutAsync(int requestId, string reason);
        Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync();
        Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync();
    }
}
