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
