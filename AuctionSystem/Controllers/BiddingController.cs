using AuctionSystem.Core.Models.Bidding;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class BiddingController : BaseController
    {
        [HttpGet]
        public IActionResult Bidding()
        {

            var model = new BiddingFormViewModel();

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(UserCommentFormViewModel model)
        //{

        //    if (await userCommentService.UserExistAsync(model.Id) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.Id), "User does not exist");

        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();
        //        return View(model);
        //    }

        //    var userId = GetUserId();
        //    await userCommentService.AddAsync(model, userId);



        //    return RedirectToAction("All", "User");

        //}
    }
}
