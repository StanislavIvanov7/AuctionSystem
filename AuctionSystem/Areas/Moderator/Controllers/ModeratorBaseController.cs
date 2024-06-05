using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AuctionSystem.Core.Constants.RoleConstants;

namespace AuctionSystem.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = ModeratorRole)]
    public class ModeratorBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
