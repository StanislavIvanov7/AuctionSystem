using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class BiddingController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
