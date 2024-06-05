using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class AdministratorHomeController : AdministartorBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
