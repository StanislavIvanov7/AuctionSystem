using AuctionSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService userCommentService;


        public UserCommentController(IUserCommentService _userCommentService)
        {
            userCommentService = _userCommentService;
        }
        //public async Task<IActionResult> All()
        //{
        //    var model = await userCommentService.AllFitnessCardAsync();

        //    return View(model);
        //}
    }
}
