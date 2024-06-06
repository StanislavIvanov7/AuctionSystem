using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class UserController : AdministartorBaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService _userService,
              UserManager<ApplicationUser> _userManager)
        {
           
            userService = _userService;
            userManager = _userManager;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsersForAdminAreaAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeUserRole(string id)
        {

            if(await userService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await userService.GetUserForEditAsync(id);


            return View(model);
        }

        [HttpPost]
     
        public async Task<IActionResult> ChangeUserRole(ChangeUserRoleViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var currentRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            if (currentRole != null)
            {
                var removeResult = await userManager.RemoveFromRoleAsync(user, currentRole);
                if (!removeResult.Succeeded)
                {
                    //ModelState.AddModelError("", "Error removing user from current role.");
                    return View(model);
                }
            }

            var addResult = await userManager.AddToRoleAsync(user, model.SelectedRole);
            if (!addResult.Succeeded)
            {
                //ModelState.AddModelError("", "Error adding user to new role.");
                return View(model);
            }

            return RedirectToAction(nameof(All));
        }
    }
}

