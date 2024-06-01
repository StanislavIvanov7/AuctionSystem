using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Extensions;
using Microsoft.AspNetCore.Mvc;

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
                model.Condition,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.AuctionPerPage);

            model.TotalAuctionCount = auctions.TotalAuctionCount;
            model.Auction = auctions.Auction;
            model.Conditions = await auctionService.AllConditionNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await auctionService.DetailsAuctionAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AuctionFormViewModel();
            model.Conditions = await auctionService.GetAuctionConditionsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionFormViewModel model)
        {

            if (await auctionService.ConditionExistAsync(model.ConditionId) == false)
            {
                ModelState.AddModelError(nameof(model.ConditionId), "Condition does not exist");

            }
            if (!ModelState.IsValid)
            {
                model.Conditions = await auctionService.GetAuctionConditionsAsync();
                return View(model);
            }
            string userId = GetUserId();
            await auctionService.AddAsync(model, userId);
            return RedirectToAction(nameof(All));

        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }

    }
}
