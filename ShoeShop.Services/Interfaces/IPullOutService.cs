<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
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
<<<<<<< HEAD
    }
}
=======
=======
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
﻿using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IPullOutService
    {
<<<<<<< HEAD
        Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto pullOutDto);
        Task<bool> ApprovePullOutAsync(int pullOutId, string managerId);
        Task<bool> RejectPullOutAsync(int pullOutId);
        Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync();
        Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync();
    }
}
=======
        Task<PullOutRequestDto> RequestPullOutAsync(CreatePullOutDto dto);
        Task<PullOutRequestDto> ApprovePullOutAsync(int requestId, string approvedBy);
        Task<PullOutRequestDto> RejectPullOutAsync(int requestId, string reason);
        Task<IEnumerable<PullOutRequestDto>> GetPendingPullOutsAsync();
        Task<IEnumerable<PullOutRequestDto>> GetPullOutHistoryAsync();
>>>>>>> origin/memberC
    }
}
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
