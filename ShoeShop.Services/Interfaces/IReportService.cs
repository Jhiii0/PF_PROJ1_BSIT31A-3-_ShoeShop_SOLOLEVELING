<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
﻿using System.Threading.Tasks;
using System;
using ShoeShop.Services.DTOs;

>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a

namespace ShoeShop.Services.Interfaces
{
    public interface IReportService
    {
<<<<<<< HEAD
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int take = 10);
    }
}
=======
<<<<<<< HEAD
        Task<IEnumerable<InventoryReportDto>> GenerateInventoryReportAsync();
        Task<IEnumerable<TransactionDto>> GenerateTransactionReportAsync();
        Task<IEnumerable<StockPullOutDto>> GenerateStockPullOutReportAsync();
    }
}
=======
        // Fixes CS0246 errors
        Task<IEnumerable<StockPullOutDto>> GetPullOutReportAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int count);
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
    }
}
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
