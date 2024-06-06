using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.UserComment;
using AuctionSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionSystem.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService userCommentService;


        public UserCommentController(IUserCommentService _userCommentService)
        {
            userCommentService = _userCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCommentAboutUserFromOtherUsers(string id)
        {
            if(await userCommentService.UserExistAsync(id) == false)
            {
                return BadRequest();
            }
            var comments = await userCommentService.GetAllCommentAboutUserFromOtherUsers(id);

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new UserCommentFormViewModel();
            //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserCommentFormViewModel model)
        {

            if (await userCommentService.UserExistAsync(model.Id) == false)
            {
                ModelState.AddModelError(nameof(model.Id), "User does not exist");

            }
            if (!ModelState.IsValid)
            {
                //model.Auctions = await auctionCommentService.GetAuctionNamesAsync();
                return View(model);
            }

            var userId = GetUserId();
            await userCommentService.AddAsync(model, userId);



            return RedirectToAction("All","User");

        }



        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
        //public async Task<IActionResult> All()
        //{
        //    var model = await userCommentService.AllFitnessCardAsync();

        //    return View(model);
        //}
    }
}
