using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionSystem.Core.Constants.MessageConstants;
using static AuctionSystem.Infrastructure.Constants.DataConstants.Auction;

namespace AuctionSystem.Core.Models.Auction
{
    public class AuctionFormViewModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName,MinimumLength = MinLengthName,ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
             MinLengthPrice,
             MaxLengthPrice,
             ConvertValueInInvariantCulture = true,
             ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal InitialPrice { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(
            MinLengthMinBiddingStep,
            MaxLengthMinBiddingStep,
            ErrorMessage = "Min bidding step must be a positive number and less than {2}")]
        public int MinBiddingStep { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(
            MinLengthBiddingPeriodInDays,
            MaxLengthBiddingPeriodInDays,
            ErrorMessage = "Min bidding period in days must be a positive number and less than {2}")]
        public int BiddingPeriodInDays { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public int ConditionId { get; set; }

        public IEnumerable<AllAuctionConditionsViewModel> Conditions { get; set; } = new List<AllAuctionConditionsViewModel>();


        public string Images { get; set; } = string.Empty;
    }
}
