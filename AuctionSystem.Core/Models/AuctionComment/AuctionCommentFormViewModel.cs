using AuctionSystem.Core.Models.Auction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Required(ErrorMessage = RequiredMessage)]
        public int AuctionId { get; set; }

        public IEnumerable<AuctionNameViewModel> Auctions { get; set; } = new List<AuctionNameViewModel>();
    }
}
