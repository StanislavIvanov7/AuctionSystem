using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuctionSystem.Infrastructure.Constants.DataConstants.ApplicationUser;
using static AuctionSystem.Core.Constants.MessageConstants;

namespace AuctionSystem.Core.Models.User
{
    public class MyInformationViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthFirstName,MinimumLength = MinLengthFirstName,ErrorMessage = LengthMessage)]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthLastName, MinimumLength = MinLengthLastName, ErrorMessage = LengthMessage)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

       
        [StringLength(MaxLengthPhoneNumber,
            MinimumLength = MinLengthPhoneNumber,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
