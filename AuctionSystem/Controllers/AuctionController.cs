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

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            if(User.IsCustomer() == false)
            {
                return Unauthorized();
            }

            var model = new AuctionFormViewModel();
            model.Conditions = await auctionService.GetAuctionConditionsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionFormViewModel model,List<string> imageUrls)
        {

            if (User.IsCustomer() == false)
            {
                return Unauthorized();
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
            string userId = GetUserId();

            await auctionService.AddAsync(model, userId);

            var auction = await auctionService.GetAuctionByNameAsync(model.Name);

            await auctionService.AddImagesAsync(auction,model.Image, imageUrls);
            var days = auction.BiddingPeriodInDays;
            var endDate = auction.StartingAuctionDateTime.AddDays(days);
            Task.Run(() => EndAuctionAfterTimeExpires(auction.Id, endDate));



            return RedirectToAction(nameof(All));

        }

        private async Task EndAuctionAfterTimeExpires(int auctionId, DateTime endDate)
        {
            await Task.Delay(endDate - DateTime.Now);


            await auctionService.SetConditionToFinish(auctionId);
         
            

        }
        [HttpGet]
        public async Task<IActionResult> EditCondition(int id)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var auction = await auctionService.GetAuctionByIdAsync(id);
            string userId = GetUserId();
            if (User.IsCustomer() && userId == auction.SellerId)
            {
                var model = await auctionService.GetModeratorAuctionForEditAsync(id);

                model.Conditions = await auctionService.GetAuctionConditionsAsync();

                return View(model);
            }
            else
            {

                return Unauthorized();
            }
           
           
        }

        [HttpPost]
        public async Task<IActionResult> EditCondition(int id, ModeratorAuctionFormViewModel model)
        {
            var auction = await auctionService.GetAuctionByIdAsync(id);
            string userId = GetUserId();
            if (User.IsCustomer() && userId == auction.SellerId)
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

                await auctionService.ModeratorEditAsync(id, model);

            

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

            //if (User.IsAdmin() == false)
            //{
            //    return Unauthorized();
            //}

            var model = await auctionService.GetAuctionForEditAsync(id);

            model.Conditions = await auctionService.GetAuctionConditionsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuctionFormViewModel model)
        {
            if (await auctionService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            //if (User.IsAdmin() == false)
            //{
            //    return Unauthorized();
            //}

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

                //return BadRequest();
            }

            else if (auction.ConditionId == 2 && User.IsModerator())
            {

                await auctionService.EditAsync(id, model);

                //return BadRequest();
            }

            //else if (User.IsCustomer() && userId == auction.SellerId)
            //{
            //    await auctionService.EditAsync(id, model);

            //}

            //else
            //{
            //    return BadRequest();
            //}

           

            //else if(User.IsModerator() || User.IsAdmin())
            //{
            //    await auctionService.EditConditionAsync(id, model);
            //}

            //await auctionService.EditAsync(id, model);

            return RedirectToAction(nameof(All));


        }
        



        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }

    }
}
