using static AuctionSystem.Core.Constants.RoleConstants;
namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
        public static bool IsModerator(this ClaimsPrincipal user)
        {
            return user.IsInRole(ModeratorRole);
        }
        public static bool IsCustomer(this ClaimsPrincipal user)
        {
            return user.IsInRole(CustomerRole);
        }
    }
}
