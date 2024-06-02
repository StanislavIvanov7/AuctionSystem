using AuctionSystem.Core.Models.User;

namespace AuctionSystem.Core.Contracts
{
    public interface IUserService
    {
        public Task<MyInformationViewModel> MyInformationAsync(string userId);

        Task<bool> ExistAsync(string id);
    }

}
