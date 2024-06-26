using System.ComponentModel.DataAnnotations;
using static AuctionSystem.Core.Constants.MessageConstants;
using static AuctionSystem.Infrastructure.Constants.DataConstants.AuctionComment;
namespace AuctionSystem.Core.Models.AuctionComment
{
    public class AuctionCommentFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthContent,MinimumLength =MinLengthContent,ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;
    }
}
