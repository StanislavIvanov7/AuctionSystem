using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Moderator.Controllers
{
    public class ModeratorHomeController : ModeratorBaseController
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
