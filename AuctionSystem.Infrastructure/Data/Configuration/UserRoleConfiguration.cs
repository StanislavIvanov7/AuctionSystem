using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(SeedUserRoles());
        }
        private List<IdentityUserRole<string>> SeedUserRoles()
        {
            IdentityUserRole<string> userRole;
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRole = new IdentityUserRole<string>()
            {
                UserId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                RoleId = "9e42b0be-39c7-48bd-883b-10726fbd7573"
            };
            userRoles.Add(userRole);
            userRole = new IdentityUserRole<string>()
            {
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                RoleId = "9e42b0be-39c7-48bd-883b-10726fbd7573"
            };
            userRoles.Add(userRole);
            userRole = new IdentityUserRole<string>()
            {
                UserId = "0e136956-3e82-4e00-8f60-b274cdf40833",
                RoleId = "346e1559-a879-404e-8555-4708cda20f06"
            };
            userRoles.Add(userRole);
            userRole = new IdentityUserRole<string>()
            {
                UserId = "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                RoleId = "e870b2a7-d550-4201-a4d6-a40bd996790a"
            };
            userRoles.Add(userRole);
            return userRoles;
        }
    }
}
