using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.AuctionComment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> AllCommentsForAuction(int id)
        {
            var model = await auctionCommentService.AllCommentsForAuctionAsync(id);

            return View(model);
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

            var userId = GetUserId();
            await auctionCommentService.AddAsync(model,userId);



            return RedirectToAction("All","Auction");

        }

        

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
