using System;

namespace ShoeShop.Services.DTOs
{
    public class StockPullOutDto
    {
        public int Id { get; set; }
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PullOutDate { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
    }
}