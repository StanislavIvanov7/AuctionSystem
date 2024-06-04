using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<MyInformationViewModel> MyInformationAsync(string userId);

        Task<bool> ExistAsync(string id);

        Task EditAsync(string id ,MyInformationViewModel model);

        Task<IEnumerable<MyAuctionViewModel>> GetMyAuctions(string userId);

        Task<IEnumerable<MyBiddingsViewModel>> GetMyBiddings(string userId);

        Task<IEnumerable<MyCommentViewModel>> GetMyComment(string userId);

        Task<IEnumerable<AllUsersViewModel>> AllUsersAsync();
    }
}

