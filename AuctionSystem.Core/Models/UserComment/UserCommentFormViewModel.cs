using System.ComponentModel.DataAnnotations;
using static AuctionSystem.Core.Constants.MessageConstants;
using static AuctionSystem.Infrastructure.Constants.DataConstants.AuctionComment;

namespace AuctionSystem.Core.Models.UserComment
{
    public class UserCommentFormViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthContent, MinimumLength = MinLengthContent, ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;
    }
}
