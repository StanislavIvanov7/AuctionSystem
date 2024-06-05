using AuctionSystem.Core.Models.Auction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuctionSystem.Core.Constants.MessageConstants;
using static AuctionSystem.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace AuctionSystem.Core.Models.User
{
    public class ChangeUserRoleViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthUserRole,MinimumLength = MinLengthUserRole,ErrorMessage = LengthMessage)]
        public string UserRole { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthUserRole, MinimumLength = MinLengthUserRole, ErrorMessage = LengthMessage)]
        public string SelectedRole { get; set; } = string.Empty;


        public IEnumerable<IdentityRole> UserRoles { get; set; } = new List<IdentityRole>();
    }
}
