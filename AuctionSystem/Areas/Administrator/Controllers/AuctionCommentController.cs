using AuctionSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class AuctionCommentController : AdministartorBaseController
    {
        private readonly IAuctionCommentService auctionCommentService;
        public AuctionCommentController(IAuctionCommentService _auctionCommentService)
        {
            auctionCommentService = _auctionCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await auctionCommentService.AllCommentsAsync();

            return View(model);
        }
    }
}
