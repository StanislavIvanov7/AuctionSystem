﻿using AuctionSystem.Core.Models.User;

namespace AuctionSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<MyInformationViewModel> MyInformationAsync(string userId);

        Task<SellerProfileViewModel> SellerProfileAsync(int auctionId);

        Task<bool> ExistAsync(string id);

        Task<bool> IsEnableAsync(string id);

        Task<bool> ExistAuctionAsync(int id);

        Task EditAsync(string id ,MyInformationViewModel model);

        Task EnableUserAsync(string id);

        Task DisableUserAsync(string id);

        Task<IEnumerable<MyAuctionViewModel>> GetMyAuctions(string userId);

        Task<IEnumerable<MyAuctionViewModel>> GetMyWinningAuctions(string userId);

        Task<IEnumerable<MyBiddingsViewModel>> GetMyBiddings(string userId);

        Task<IEnumerable<MyAuctionCommentViewModel>> GetMyAuctionComment(string userId);

        Task<IEnumerable<MyUserCommentViewModel>> GetMyUserComment(string userId);

        Task<IEnumerable<AllUsersViewModel>> AllUsersAsync();

        Task<DetailsUsersViewModel> DetailsUsersAsync(string id);

        Task<IEnumerable<DetailsUsersViewModel>> AllUsersForAdminAreaAsync();

        Task<IEnumerable<AllUsersViewModel>> AllUsersForEnableForAdminAreaAsync();

        Task<ChangeUserRoleViewModel> GetUserForEditAsync(string id);

        Task<DeleteUserViewModel> GetUserForDeleteAsync(string id);

        Task RemoveAsync(string id);
    }
}
