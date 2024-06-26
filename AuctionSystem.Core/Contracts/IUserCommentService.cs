using AuctionSystem.Core.Models.UserComment;
namespace AuctionSystem.Core.Contracts
{
    public interface IUserCommentService
    {
        Task<bool> UserExistAsync(string id);
        Task AddAsync(UserCommentFormViewModel model, string userId);
        Task<IEnumerable<AllUserCommentsViewModel>> AllCommentsAsync();
        Task<bool> ExistAsync(int id);
        Task<DeleteUserCommentViewModel> GetUserCommentForDeleteAsync(int id);
        Task RemoveAsync(int id);
        Task<IEnumerable<AllCommentAboutUserFromOtherUsers>> GetAllCommentAboutUserFromOtherUsers(string userId);
        Task<IEnumerable<AllUserCommentForOtherUsers>> GetAllUserCommentsForOtherUsers(string userId);
    }
}
