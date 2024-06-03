using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Services;
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
            model.Auctions = await auctionCommentService.GetAuctionNamesAsync();

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(AuctionFormViewModel model, List<string> imageUrls)
        //{

        //    if (await auctionService.ConditionExistAsync(model.ConditionId) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.ConditionId), "Condition does not exist");

        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        model.Conditions = await auctionService.GetAuctionConditionsAsync();
        //        return View(model);
        //    }
        //    string userId = GetUserId();
        //    await auctionService.AddAsync(model, userId);

        //    var auction = await auctionService.GetAuctionByNameAsync(model.Name);

        //    await auctionService.AddImagesAsync(auction, imageUrls);



        //    return RedirectToAction(nameof(All));

        //}
    }
}
