using AuctionSystem.Infrastructure.Data.Models;
namespace AuctionSystem.Core.Models.User
{
    public class MyAuctionViewModel
    {
        public int Id { get; set; }
        public int ConditionId { get; set; }
        public string  Condition { get; set; } = string.Empty;
        public string SellerId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal LastPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<AuctionImage> Images { get; set; } = new List<AuctionImage>();
        public int BiddingPeriodInDays { get; set; }
        public int MinBiddingStep { get; set; }
    }
}
