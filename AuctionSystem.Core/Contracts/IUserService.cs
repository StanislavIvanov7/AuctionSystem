using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<MyInformationViewModel> MyInformationAsync(string userId);

        Task<SellerProfileViewModel> SellerProfileAsync(int auctionId);

        Task<bool> ExistAsync(string id);

        Task EditAsync(string id ,MyInformationViewModel model);

        Task<IEnumerable<MyAuctionViewModel>> GetMyAuctions(string userId);

        Task<IEnumerable<MyAuctionViewModel>> GetMyWinningAuctions(string userId);

        Task<IEnumerable<MyBiddingsViewModel>> GetMyBiddings(string userId);

        Task<IEnumerable<MyAuctionCommentViewModel>> GetMyAuctionComment(string userId);
        Task<IEnumerable<MyUserCommentViewModel>> GetMyUserComment(string userId);

        Task<IEnumerable<AllUsersViewModel>> AllUsersAsync();

        Task<ChangeUserRoleViewModel> GetUserForEditAsync(string id);

    }
}

