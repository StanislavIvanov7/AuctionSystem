using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionSystem.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IAuctionService auctionService;

        public AuctionController(IAuctionService service)
        {
            auctionService = service;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AuctionQueryViewModel model)
        {
            var auctions = await auctionService.AllAuctionAsync(
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.AuctionPerPage);

            model.TotalAuctionCount = auctions.TotalAuctionCount;
            model.Auction = auctions.Auction;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllAuctionsForUser(string id)
        {
            if (await auctionService.UserExistAsync(id) == false)
            {
                return BadRequest();
            }

            var auctions = await auctionService.GetAllAuctionsForUser(id);

            return View(auctions);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await auctionService.DetailsAuctionAsync(id);

            if(model.ConditionId == 4)
            {
                return View(model);
            }
            else
            {
                return BadRequest();
            }
        }
      
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if(User.IsCustomer() == false)
            {
                return Unauthorized();
            }

            var model = new AuctionFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionFormViewModel model, List<string> imageUrls)
        {
            if (!User.IsCustomer())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();

            int auctionId =  await auctionService.AddAsync(model, userId);
            var auction = await auctionService.GetAuctionByIdAsync(auctionId);

            await auctionService.AddImagesAsync(auction, model.Image, imageUrls);

            var days = auction.BiddingPeriodInDays;
            var endDate = auction.StartingAuctionDateTime.AddDays(days);

            ScheduleAuctionCompletion(auction.Id, endDate);

            return RedirectToAction(nameof(All));
        }

        private void ScheduleAuctionCompletion(int auctionId, DateTime endDate)
        {
            var delay = endDate - DateTime.Now;

            if (delay <= TimeSpan.Zero)
            {
                Task.Run(() => EndAuctionAfterTimeExpires(auctionId));
            }
            else
            {
                Task.Delay(delay).ContinueWith(_ => EndAuctionAfterTimeExpires(auctionId));
            }
        }
        private async Task EndAuctionAfterTimeExpires(int auctionId)
        {
            await auctionService.SetConditionToFinish(auctionId);
        }
        [HttpGet]
        public async Task<IActionResult> TerminateAuction(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var auction = await auctionService.GetAuctionByIdAsync(id);

            if(auction.ConditionId != 4)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (User.IsCustomer() && userId == auction.SellerId)
            {
                await auctionService.TerminateAuction(auction.Id);
                return RedirectToAction(nameof(All));
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var auction = await auctionService.GetAuctionByIdAsync(id);
            string userId = GetUserId();

            if (auction.ConditionId == 1 && userId == auction.SellerId)
            {
                var model = await auctionService.GetAuctionForEditAsync(id);
                model.Conditions = await auctionService.GetOnlyTwoAuctionConditionsAsync();

                return View(model);
            }
            else if (auction.ConditionId == 2 && User.IsModerator())
            {
                var model = await auctionService.GetAuctionForEditAsync(id);
                model.Conditions = await auctionService.GetAuctionConditionsAsync();

                return View(model);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuctionFormViewModel model)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await auctionService.ConditionExistAsync(model.ConditionId) == false)
            {
                ModelState.AddModelError(nameof(model.ConditionId), "Condition does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Conditions = await auctionService.GetAuctionConditionsAsync();
                return View(model);
            }

            var auction = await auctionService.GetAuctionByIdAsync(id);
            var userId = GetUserId();

            if (auction.ConditionId == 1 && userId == auction.SellerId)
            {
                await auctionService.EditAsync(id, model);
            }

            else if (auction.ConditionId == 2 && User.IsModerator())
            {
                await auctionService.EditAsync(id, model);
            }

            return RedirectToAction("MyAuctions", "User");
        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);

            return userId;
        }
    }
}
