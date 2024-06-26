using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionSystem.Infrastructure.Constants.DataConstants.UserComment;
namespace AuctionSystem.Infrastructure.Data.Models
{
    [Comment("User Comment Table")]
    public class UserComment
    {
        [Key]
        [Comment("User Comment Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Sending Comment User Identifier")]
        public string SendingCommentUserId { get; set; } = string.Empty;
        [Required]
        [Comment("Receiving Comment User Identifier")]
        public string ReceivingCommentUserId { get; set; } = string.Empty;
        [Required]
        [MaxLength(MaxLengthContent)]
        public string Content { get; set; } = string.Empty;
        [ForeignKey(nameof(ReceivingCommentUserId))]
        public ApplicationUser Receiver { get; set; } = null!;
        [ForeignKey(nameof(SendingCommentUserId))]
        public ApplicationUser Sender { get; set; } = null!;
    }
}
