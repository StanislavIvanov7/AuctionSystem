using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(SeedRoles());
        }
        private List<IdentityRole> SeedRoles()
        {
            IdentityRole role;
            List<IdentityRole> roles = new List<IdentityRole>();
            role = new IdentityRole()
            {
                Id = "9e42b0be-39c7-48bd-883b-10726fbd7573",
                Name = "Customer",
                NormalizedName = "CUSTOMER",
            };
            roles.Add(role);
            role = new IdentityRole()
            {
                Id = "346e1559-a879-404e-8555-4708cda20f06",
                Name = "Moderator",
                NormalizedName = "MODERATOR",
            };
            roles.Add(role);
            role = new IdentityRole()
            {
                Id = "e870b2a7-d550-4201-a4d6-a40bd996790a",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            };
            roles.Add(role);
            return roles;
        }
    }
}
