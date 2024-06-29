using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AuctionSystem.Infrastructure.Constants.DataConstants.AuctionCondition;

namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("Auction Condition table")]
    public class AuctionCondition
    {
        [Key]
        [Comment("Condition Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        [Comment("Auction Condition Name")]
        public string Name { get; set; } = string.Empty;

        public List<Auction> Auctions { get; set; } = new List<Auction>();
    }
}
