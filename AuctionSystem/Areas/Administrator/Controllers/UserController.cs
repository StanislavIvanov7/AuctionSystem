using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Core.Services;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using System.Security.Claims;
using static AuctionSystem.Core.Constants.CustomClaim;
using static AuctionSystem.Core.Constants.RoleConstants;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    public class UserController : AdministartorBaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUserService _userService,
              UserManager<ApplicationUser> _userManager,
              SignInManager<ApplicationUser> _signInManager)
        {
           
            userService = _userService;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsersForAdminAreaAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllUserForEnable()
        {
            var model = await userService.AllUsersForEnableForAdminAreaAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Enable(string id)
        {
            if(await userService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

           
            await userService.EnableUserAsync(id);

            return RedirectToAction(nameof(AllUserForEnable));
        }

        [HttpGet]
        public async Task<IActionResult> DisableUsers(string id)
        {
            if (await userService.ExistAsync(id) == false)
            {
                return BadRequest();
            }


            await userService.DisableUserAsync(id);

            return RedirectToAction(nameof(All));
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new RegisterFormModel();
           

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterFormModel model)
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            await userManager.SetEmailAsync(applicationUser, model.Email);
            await userManager.SetUserNameAsync(applicationUser, model.Email);

            var result = await userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(UserFullNameClaim, $"{applicationUser.FirstName} {applicationUser.LastName}"));
            await userManager.AddToRoleAsync(applicationUser, CustomerRole);

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (await userService.ExistAsync(id) == false)
            {
                return BadRequest();
            }


            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await userService.GetUserForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            if (await userService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await userService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}

