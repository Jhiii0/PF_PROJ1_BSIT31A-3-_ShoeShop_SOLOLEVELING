namespace ShoeShop.Services.DTOs
{
    public class StockPullOutDto
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string ShoeName { get; set; }   // optional: depende kung kailangan mo
        public int Quantity { get; set; }
        public DateTime PullOutDate { get; set; }
        public string Status { get; set; }     // e.g. Pending, Approved, Rejected
    }
}
