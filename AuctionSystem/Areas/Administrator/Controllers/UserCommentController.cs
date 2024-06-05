using AuctionSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class UserCommentController : AdministartorBaseController
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
