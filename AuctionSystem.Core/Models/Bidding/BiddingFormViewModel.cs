using System.ComponentModel.DataAnnotations;

using static AuctionSystem.Core.Constants.MessageConstants;
using static AuctionSystem.Infrastructure.Constants.DataConstants.Bidding;

namespace AuctionSystem.Core.Models.Bidding
{
    public class BiddingFormViewModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
             MinLengthLastPrice,
             MaxLengthLastPrice,
             ConvertValueInInvariantCulture = true,
             ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal LastPrice { get; set; } 
    }
}
