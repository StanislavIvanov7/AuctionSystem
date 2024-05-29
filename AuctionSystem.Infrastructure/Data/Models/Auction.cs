using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionSystem.Infrastructure.Constants.DataConstants.Auction;

namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("Auction table")]
    public class Auction
    {
        [Key]
        [Comment("Auction Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxLengthName)]
        [Comment("Auction Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Auction Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Auction Initial Price")]
        public decimal InitialPrice { get; set; }

        [Required]
        [Comment("Auction Min Bidding Step")]
        public int MinBiddingStep { get; set; }

        [Required]
        [Comment("Auction Bidding Period In Days")]
        public int BiddingPeriodInDays { get; set; }

        [Required]
        [Comment("Auction Condition Identifier")]
        public int ConditionId { get; set; }

        [ForeignKey(nameof(ConditionId))]
        public AuctionCondition Condition { get; set; } = null!;

        [Required]
        [Comment("Auction Seller Identifier")]
        public string SellerId { get; set; } = string.Empty;

        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("Auction Last Price")]
        public decimal LastPrice { get; set; }


        [Comment("Auction Last Buyer Identifier")]
        public string? LastBuyerId { get; set; }

        [ForeignKey(nameof(LastBuyerId))]
        public IdentityUser? LastBuyer { get; set; }
      
        public List<AuctionImage> Images { get; set; } = new List<AuctionImage>();
    }
}
