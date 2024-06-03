using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Services;
using AuctionSystem.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class AuctionCommentController : Controller
    {
        private readonly IAuctionCommentService auctionCommentService;
        public AuctionCommentController(IAuctionCommentService _auctionCommentService)
        {
            auctionCommentService = _auctionCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AuctionCommentFormViewModel();
            //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionCommentFormViewModel model)
        {

            if (await auctionCommentService.AuctionExistAsync(model.Id) == false)
            {
                ModelState.AddModelError(nameof(model.Id), "Auction does not exist");

            }
            if (!ModelState.IsValid)
            {
                //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();
                return View(model);
            }
           
            await auctionCommentService.AddAsync(model);



            return RedirectToAction("All","Auction");

        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
