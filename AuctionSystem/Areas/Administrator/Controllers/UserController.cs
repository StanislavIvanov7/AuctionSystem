using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Services;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class UserController : AdministartorBaseController
    {
        private readonly IUserService userService;


        public UserController(IUserService _userService)
        {
           
            userService = _userService;
      

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsersAsync();

            return View(model);
        }
    }
}
