﻿using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.UserComment;
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



            return RedirectToAction("");

        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (await userCommentService.ExistAsync(id) == false)
        //    {
        //        return BadRequest();
        //    }

        //    if (User.IsModerator() == false && User.IsAdmin() == false)
        //    {
        //        return Unauthorized();
        //    }

        //    var model = await userCommentService.GetUserCommentForDeleteAsync(id);

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //    if (await userCommentService.ExistAsync(id) == false)
        //    {
        //        return BadRequest();
        //    }

        //    if (User.IsModerator() == false && User.IsAdmin() == false)
        //    {
        //        return Unauthorized();
        //    }

        //    await userCommentService.RemoveAsync(id);

        //    return RedirectToAction(nameof(All));

        //}

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
