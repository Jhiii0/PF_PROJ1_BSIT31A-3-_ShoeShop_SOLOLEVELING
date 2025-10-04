<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
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
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7

namespace ShoeShop.Services.Interfaces
{
    public interface IReportService
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int take = 10);
    }
}
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        Task<IEnumerable<InventoryReportDto>> GenerateInventoryReportAsync();
        Task<IEnumerable<TransactionDto>> GenerateTransactionReportAsync();
        Task<IEnumerable<StockPullOutDto>> GenerateStockPullOutReportAsync();
    }
}
<<<<<<< HEAD
=======
=======
        // Fixes CS0246 errors
        Task<IEnumerable<StockPullOutDto>> GetPullOutReportAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockPullOutDto>> GetRecentPullOutsAsync(int count);
        Task<InventoryReportDto> GetInventoryDashboardReportAsync();
    }
}
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
