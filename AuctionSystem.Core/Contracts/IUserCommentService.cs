using AuctionSystem.Core.Models.UserComment;

namespace AuctionSystem.Core.Contracts
{
    public interface IUserCommentService
    {
        Task<bool> UserExistAsync(string id);

        Task AddAsync(UserCommentFormViewModel model, string userId);
    }
}
