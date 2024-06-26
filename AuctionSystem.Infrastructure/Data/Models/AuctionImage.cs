using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionSystem.Infrastructure.Constants.DataConstants.AuctionImage;
namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("Auction Image Table")]
    public class AuctionImage
    {
        [Key]
        [Comment("Image Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Image Url")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [Comment("Is Main Image")]
        public bool IsMain { get; set; }
        [Required]
        [Comment("Auction Identifier")]
        public int AuctionId { get; set; }
        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; } = null!;
    }
}
