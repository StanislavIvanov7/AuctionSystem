namespace AuctionSystem.Core.Models.User
{
    public class MyBiddingsViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string DateAndTimeOfBidding { get; set; } = string.Empty;
        public string AuctionName { get; set; } = string.Empty;
        public string AuctionImageUrl { get; set; } = string.Empty;
    }
}
