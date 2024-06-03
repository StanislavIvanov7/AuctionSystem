using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AllUsersViewModel>> AllUsersAsync()
        {
            var users = await repository.AllAsReadOnly<ApplicationUser>()
                .Select(x => new AllUsersViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,

                }).ToListAsync();

            return users;
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
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    Images = x.Images
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

                }).ToListAsync();

            return biddings;
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
    }
}
