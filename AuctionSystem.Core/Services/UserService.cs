using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserService(IRepository _repository, 
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            repository = _repository;
            userManager = _userManager; 
            roleManager = _roleManager;
        }

        public async Task<IEnumerable<AllUsersViewModel>> AllUsersAsync()
        {

            //var users = await repository.AllAsReadOnly<ApplicationUser>()
            //    .Select(x => new AllUsersViewModel()
            //    {
            //        Id = x.Id,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        Email = x.Email,
            //        PhoneNumber = x.PhoneNumber,
            //        UserRole = await userManager.GetRolesAsync(user)

            //    }).ToListAsync();
             var users = userManager.Users.ToList();
            var allUsers = new List<AllUsersViewModel>();

            foreach (var user in users)
            {
                var role = await userManager.GetRolesAsync(user);

                var model = new AllUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                   
                };

                allUsers.Add(model);
            }

            return allUsers;
        }

        public async Task EditAsync(string id,MyInformationViewModel model)
        {
            var user = await repository.All<ApplicationUser>()
                .FirstOrDefaultAsync(x=>x.Id == id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.PhoneNumber = model.PhoneNumber;
                
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MyAuctionViewModel>> GetMyAuctions(string userId)
        {
           var auctions = await repository.AllAsReadOnly<Auction>()
                .Where(x=>x.SellerId == userId)
                .Select(x=> new MyAuctionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Condition = x.Condition.Name,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    Images = x.Images,
                    ConditionId = x.ConditionId,
                    SellerId = x.SellerId 
                }).ToListAsync();

            return auctions;
        }

        public async Task<IEnumerable<MyBiddingsViewModel>> GetMyBiddings(string userId)
        {
            var biddings = await repository.AllAsReadOnly<Bidding>()
                .Where(x => x.BuyerId == userId)
                .Select(x => new MyBiddingsViewModel()
                {
                    Id = x.Id,
                    Price = x.Price,
                    DateAndTimeOfBidding = x.DateAndTimeOfBidding.ToString(),
                    AuctionName = x.Auction.Name,
                    AuctionImageUrl = x.Auction.Images.First().ImageUrl,
                    

                }).ToListAsync();

            return biddings;
        }

        public async  Task<IEnumerable<MyAuctionCommentViewModel>> GetMyAuctionComment(string userId)
        {
            var comments = await repository.AllAsReadOnly<AuctionComment>()
                .Where(x => x.UserId == userId)
                .Select(x => new MyAuctionCommentViewModel()
                {
                    //Id = x.Id,
                    Content = x.Content, 
                    AuctionName = x.Auction.Name,
                    AuctionImageUrl = x.Auction.Images.First().ImageUrl



                }).ToListAsync();

            return comments;
        }

        public async Task<MyInformationViewModel> MyInformationAsync(string userId)
        {
            var user = await repository.AllAsReadOnly<ApplicationUser>()
                  .Where(x=>x.Id == userId)
                  .Select(x => new MyInformationViewModel()
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      Email = x.Email,
                      PhoneNumber = x.PhoneNumber,

                  }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<ChangeUserRoleViewModel> GetUserForEditAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var model = new ChangeUserRoleViewModel()
            {
                UserId = user.Id,
                UserRole = (await userManager.GetRolesAsync(user)).FirstOrDefault(),
                UserRoles = roleManager.Roles.ToList(),
            };

            return model;
        }

        public async Task<IEnumerable<MyUserCommentViewModel>> GetMyUserComment(string userId)
        {
            var comments = await repository.AllAsReadOnly<UserComment>()
                .Where(x => x.SendingCommentUserId == userId)
                .Select(x => new MyUserCommentViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReceivingCommentUserName = x.User2.FirstName + " " + x.User2.LastName,
                   



                }).ToListAsync();

            return comments;
        }

        public async Task<SellerProfileViewModel> SellerProfileAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);
          
            string userIdentifier = auction.SellerId;

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userIdentifier)
                .Select(x => new SellerProfileViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,

                }).FirstOrDefaultAsync();

            return user;

        }

        public async Task<IEnumerable<MyAuctionViewModel>> GetMyWinningAuctions(string userId)
        {
            
            var auctions = await repository.AllAsReadOnly<Auction>()
                .Include(x=>x.Images)
                .ToListAsync();
            List<Auction> CompletedAuction = new List<Auction>();

            foreach (var auction in auctions) 
            {
                var days = auction.BiddingPeriodInDays;
                var finalDateTime = auction.StartingAuctionDateTime.AddDays(days);
                if(finalDateTime < DateTime.Now)
                {
                    CompletedAuction.Add(auction);
                }

            }

            var result = CompletedAuction
                .Where(x => x.LastBuyerId == userId)
                .Select(x => new MyAuctionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    Images = x.Images
                }).ToList();

            return result;
        }

        public async Task<DetailsUsersViewModel> DetailsUsersAsync(string id)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

                var role = await userManager.GetRolesAsync(user);

                var model = new DetailsUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserRole = role.FirstOrDefault()
                };

            return model;

        }

        public async Task<IEnumerable<DetailsUsersViewModel>> AllUsersForAdminAreaAsync()
        {
            var users = userManager.Users.ToList();
            var allUsers = new List<DetailsUsersViewModel>();

            foreach (var user in users)
            {
                var role = await userManager.GetRolesAsync(user);

                var model = new DetailsUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserRole = role.FirstOrDefault()
                };

                allUsers.Add(model);
            }

            return allUsers;
        }

        public async Task<bool> ExistAuctionAsync(int id)
        {
            return await repository.AllAsReadOnly<Auction>()
                 .AnyAsync(x => x.Id == id);
        }

        public async Task<DeleteUserViewModel> GetUserForDeleteAsync(string id)
        {
            var user = await repository.AllAsReadOnly<ApplicationUser>()
               .Where(x => x.Id == id)
               .Select(x => new DeleteUserViewModel()
               {
                   Id = x.Id,
                   FirstName = x.FirstName,
                   LastName = x.LastName,

               })
               .FirstAsync();

            return user;
        }

        public async Task RemoveAsync(string id)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                repository.Delete<ApplicationUser>(user);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEnableAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
               .AnyAsync(x => x.Id == id && x.Enable == true);
        }

        public async Task<IEnumerable<AllUsersViewModel>> AllUsersForEnableForAdminAreaAsync()
        {
            var users = userManager.Users.Where(x=>x.Enable == false).ToList();
            var allUsers = new List<AllUsersViewModel>();

            foreach (var user in users)
            {
                

                var model = new AllUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                   
                };

                allUsers.Add(model);
            }

            return allUsers;
        }

        public async Task EnableUserAsync(string id)
        {
            var user = await repository.All<ApplicationUser>()
                .Where (x=>x.Id == id && x.Enable == false)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                user.Enable = true;
                await repository.SaveChangesAsync();

            }
        }
    }
}
