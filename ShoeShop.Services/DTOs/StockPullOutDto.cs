<<<<<<< HEAD
﻿using ShoeShop.Repository.Entities;
using System; // Idinagdag ang System para sa DateTime

namespace ShoeShop.Services.DTOs
=======
﻿namespace ShoeShop.Services.DTOs
>>>>>>> origin/memberC
{
    public class StockPullOutDto
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
<<<<<<< HEAD
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // FINAL FIX: Idinagdag ang missing property
        public DateTime PullOutDate { get; set; }
    }
}
=======
        public string ShoeName { get; set; }   // optional: depende kung kailangan mo
        public int Quantity { get; set; }
        public DateTime PullOutDate { get; set; }
        public string Status { get; set; }     // e.g. Pending, Approved, Rejected
    }
}
>>>>>>> origin/memberC
