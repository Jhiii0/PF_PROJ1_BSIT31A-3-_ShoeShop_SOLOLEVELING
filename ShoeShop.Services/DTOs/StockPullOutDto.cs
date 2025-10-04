<<<<<<< HEAD
=======
<<<<<<< HEAD
﻿using System;

namespace ShoeShop.Services.DTOs
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
﻿using ShoeShop.Repository.Entities;
using System; // Idinagdag ang System para sa DateTime

namespace ShoeShop.Services.DTOs
<<<<<<< HEAD
=======
=======
﻿namespace ShoeShop.Services.DTOs
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
{
    public class StockPullOutDto
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public int ShoeId { get; set; }
=======
<<<<<<< HEAD
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PullOutDate { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
    }
}
=======
        public int ShoeId { get; set; }
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // FINAL FIX: Idinagdag ang missing property
        public DateTime PullOutDate { get; set; }
    }
<<<<<<< HEAD
}
=======
}
=======
        public string ShoeName { get; set; }   // optional: depende kung kailangan mo
        public int Quantity { get; set; }
        public DateTime PullOutDate { get; set; }
        public string Status { get; set; }     // e.g. Pending, Approved, Rejected
    }
}
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
