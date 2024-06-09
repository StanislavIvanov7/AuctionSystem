using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static AuctionSystem.Infrastructure.Constants.DataConstants.ApplicationUser;
namespace AuctionSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength(MaxLengthFirstName)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthLastName)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public bool Enable { get; set; } = false;

        public List<AuctionComment> AuctionComments = new List<AuctionComment>();

        public List<UserComment> UserComments = new List<UserComment>();

    }
}
