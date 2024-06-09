namespace AuctionSystem.Core.Models.Bidding
{
    public class AllBiddingsViewModel
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public decimal Price { get; set; }

        public string DateAndTimeOfBidding { get; set; } = string.Empty;

        public string AuctionName { get; set; } = string.Empty;

        public string BiddingUser { get; set; } = string.Empty;

        public string AuctionImageUrl { get; set; } = string.Empty;
    }
}
