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
        public async Task<IActionResult> All()
        {
            var model = await auctionCommentService.AllCommentsAsync();

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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await auctionCommentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsModerator() == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await auctionCommentService.GetCommentForDeleteAsync(id);

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //    if (await dietService.ExistAsync(id) == false)
        //    {
        //        return BadRequest();
        //    }

        //    if (User.IsAdmin() == false)
        //    {
        //        return Unauthorized();
        //    }

        //    await dietService.RemoveAsync(id);

        //    return RedirectToAction(nameof(All));

        //}

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
