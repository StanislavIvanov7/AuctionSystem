using AuctionSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class AuctionCommentController : AdministartorBaseController
    {
        private readonly IAuctionCommentService auctionCommentService;

        public AuctionCommentController(IAuctionCommentService _auctionCommentService)
        {
            auctionCommentService = _auctionCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await auctionCommentService.AllCommentsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await auctionCommentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsModerator() == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await auctionCommentService.GetCommentForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await auctionCommentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsModerator() == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await auctionCommentService.RemoveAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
