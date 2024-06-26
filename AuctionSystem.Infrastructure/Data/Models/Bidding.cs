﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("Bidding Table")]
    public class Bidding
    {
        [Key]
        [Comment("Bidding Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Buyer Identifier")]
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        [Comment("Auction Identifier")]
        public int AuctionId { get; set; }

        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; } = null!;

        [Required]
        [Comment("Date And Time Of Bidding")]
        public DateTime DateAndTimeOfBidding { get; set; }

        [Required]
        [Comment("Bidding Price")]
        public decimal Price { get; set; }
    }
}
