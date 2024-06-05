using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
