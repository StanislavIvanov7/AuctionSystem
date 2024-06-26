using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.AuctionComment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace AuctionSystem.Controllers
{
    public class AuctionCommentController : Controller
    {
        private readonly IAuctionCommentService auctionCommentService;
        public AuctionCommentController(IAuctionCommentService _auctionCommentService)
        {
            auctionCommentService = _auctionCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> AllCommentsForAuction(int id)
        {
            if(await auctionCommentService.AuctionExistAsync(id)== false)
            {
                return BadRequest();
            }
            var model = await auctionCommentService.AllCommentsForAuctionAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AllAuctionCommentsFromUser(string id)
        {
            if (await auctionCommentService.UserExistAsync(id) == false)
            {
                return BadRequest();
            }
            var comments = await auctionCommentService.GetAllAuctionCommentsFromUser(id);
            return View(comments);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AuctionCommentFormViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AuctionCommentFormViewModel model)
        {
            if (await auctionCommentService.AuctionExistAsync(model.Id) == false)
            {
                ModelState.AddModelError(nameof(model.Id), "Auction does not exist");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = GetUserId();
            await auctionCommentService.AddAsync(model,userId);
            return RedirectToAction("All","Auction");
        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
