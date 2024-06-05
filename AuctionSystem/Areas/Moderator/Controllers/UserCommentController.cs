using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionSystem.Areas.Moderator.Controllers
{
    public class UserCommentController : ModeratorBaseController
    {
        private readonly IUserCommentService userCommentService;


        public UserCommentController(IUserCommentService _userCommentService)
        {
            userCommentService = _userCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userCommentService.AllCommentsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await userCommentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsModerator() == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await userCommentService.GetUserCommentForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (await userCommentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsModerator() == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await userCommentService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }
    }
}
