using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Bidding;
using AuctionSystem.Core.Services;
using AuctionSystem.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class BiddingController : BaseController
    {
        private readonly IBiddingService biddingService;

        public BiddingController(IBiddingService _biddingService)
        {
            biddingService = _biddingService;

        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await biddingService.AllBiddingsAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Bidding()
        {

            var model = new BiddingFormViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Bidding(BiddingFormViewModel model)
        {

            if (await biddingService.AuctionExistAsync(model.Id) == false)
            {
                ModelState.AddModelError(nameof(model.Id), "Auction does not exist");

            }

            var auction = await biddingService.GetAuctionByIdAsync(model.Id);

            if (!await biddingService.IsActiveAsync(auction.Id))
            {
                return BadRequest();
            }

            if (!await biddingService.IsValidAsync(auction.Id))
            {
                return BadRequest();
            }

          

            var minBiddingPrice = auction.LastPrice + auction.MinBiddingStep;
            if (minBiddingPrice > model.LastPrice)
            {
                //ModelState.AddModelError(nameof(model.Id), $"Price must be bigger than {minBiddingPrice}");
                return View(model);
            }
            //var days = auction.BiddingPeriodInDays;
            //var finalDateTime = auction.StartingAuctionDateTime.AddDays(days);


            //if (finalDateTime > DateTime.Now)
            //{

            //    return BadRequest();

            //}


            if (!ModelState.IsValid)
            {
                //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();
                return View(model);
            }

            var userId = GetUserId();
            await biddingService.AddBiddingAsync(model, userId);
            await biddingService.SetNewValuesForAuctionAsync(model,auction.Id);
            //auction.LastPrice = model.LastPrice;



            return RedirectToAction("All", "Auction");

        }



        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
