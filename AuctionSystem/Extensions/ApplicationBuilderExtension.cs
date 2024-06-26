using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static AuctionSystem.Core.Constants.RoleConstants;
namespace Microsoft.AspNetCore.Builder;
public static class ApplicationBuilderExtension
{
    public static async Task CreateRolesAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        if (roleManager != null && userManager != null
            && await roleManager.RoleExistsAsync(AdminRole) == false
            && await roleManager.RoleExistsAsync(ModeratorRole) == false
            && await roleManager.RoleExistsAsync(CustomerRole) == false)
        {
            var role = new IdentityRole(AdminRole);
            var role2 = new IdentityRole(ModeratorRole);
            var role3 = new IdentityRole(CustomerRole);
            await roleManager.CreateAsync(role);
            await roleManager.CreateAsync(role2);
            await roleManager.CreateAsync(role3);
            var admin = await userManager.FindByEmailAsync("stanislav@abv.bg");
            var moderator = await userManager.FindByEmailAsync("petq@abv.bg");
            var customer = await userManager.FindByEmailAsync("pesho@abv.bg");
            if (admin != null)
            {
                await userManager.AddToRoleAsync(admin, role.Name);
            }
            if(moderator != null)
            {
                await userManager.AddToRoleAsync(moderator, role2.Name);
            }
            if (customer != null)
            {
                await userManager.AddToRoleAsync(customer, role3.Name);
            }
        }
    }
}
