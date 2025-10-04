<<<<<<< HEAD
﻿using System.Threading.Tasks;
using System.Collections.Generic;
// Tiyakin na ito ang tamang path sa iyong DTOs
using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Interfaces
{
    // Interface para sa Stock Pull Out operations (Fixes IPullOutService error)
    public interface IPullOutService
    {
        // Sample method para sa pagkuha ng lahat ng pull out history
        Task<IEnumerable<StockPullOutDto>> GetAllPullOutsAsync();
=======
﻿using ShoeShop.Services.DTOs;
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
>>>>>>> origin/memberC
    }
}
