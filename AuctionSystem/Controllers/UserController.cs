using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Core.Services;
using AuctionSystem.Extensions;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static AuctionSystem.Core.Constants.CustomClaim;
using static AuctionSystem.Core.Constants.RoleConstants;
namespace AuctionSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public UserController(SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            IUserStore<ApplicationUser> _userStore,
            IUserService _userService)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            userService = _userService;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
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
            await signInManager.SignInAsync(applicationUser, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "There was an error while logging you in! Please try again later or contact an administrator.");

                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            //if (await userManager.IsInRoleAsync(user, AdminRole))
            //{
            //    return RedirectToAction("DashBoard", "Home", new { area = "Admin" });
            //}
            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
        [HttpGet]
        public async Task<IActionResult> MyInfo()
        {
            var userId = GetUserId();
            var model = await userService.MyInformationAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
           
            var user = await userManager.GetUserAsync(User);

            if(user == null)
            {
                return NotFound();
            }

            var model = new MyInformationViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MyInformationViewModel model)
        {
            //if (await auctionService.ExistAsync(id) == false)
            //{
            //    return BadRequest();
            //}

            ////if (User.IsAdmin() == false)
            ////{
            ////    return Unauthorized();
            ////}

            //if (await auctionService.ConditionExistAsync(model.ConditionId) == false)
            //{
            //    ModelState.AddModelError(nameof(model.ConditionId), "Condition does not exist");
            //}

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.GetUserAsync(User);

            if(user == null)
            {
                return NotFound();
            }


            await userService.EditAsync(user.Id, model);

            return RedirectToAction(nameof(MyInfo));


        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
