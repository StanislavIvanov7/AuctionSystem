﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionSystem.Infrastructure.Constants.DataConstants.AuctionComment;
namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("Auction Comment Table")]
    public class AuctionComment
    {
        [Key]
        [Comment("Auction Comment Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Comment Identifier")]
        public int AuctionId { get; set; }

        [Required]
        [MaxLength(MaxLengthContent)]
        public string Content { get; set; } = string.Empty;

        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; } = null!;

    }
}
