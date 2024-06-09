using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Edit(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await auctionService.GetModeratorAuctionForEditAsync(id);

            model.Conditions = await auctionService.GetAuctionConditionsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ModeratorAuctionFormViewModel model)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var auction = await auctionService.GetAuctionByIdAsync(id);
            if(auction.ConditionId == 1  || auction.ConditionId == 2)
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

          
           
            await auctionService.ModeratorEditAsync(id, model);


            return RedirectToAction(nameof(All));


        }

       
    }
}
