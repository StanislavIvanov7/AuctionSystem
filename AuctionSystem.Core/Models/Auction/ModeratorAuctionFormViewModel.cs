using System.ComponentModel.DataAnnotations;
using static AuctionSystem.Core.Constants.MessageConstants;

namespace AuctionSystem.Core.Models.Auction
{
    public class ModeratorAuctionFormViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public int ConditionId { get; set; }

        public IEnumerable<AllAuctionConditionsViewModel> Conditions { get; set; } = new List<AllAuctionConditionsViewModel>();
    }
}
