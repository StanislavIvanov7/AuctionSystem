using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class AuctionController : AdministartorBaseController
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
    }
}
