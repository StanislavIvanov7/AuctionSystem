using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.UserComment;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace AuctionSystem.Core.Services
{
    public class UserCommentService : IUserCommentService
    {
        private readonly IRepository repository;
        public UserCommentService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task AddAsync(UserCommentFormViewModel model, string userId)
        {
            UserComment comment = new UserComment()
            {
                Content = model.Content,
                SendingCommentUserId = userId,
                ReceivingCommentUserId = model.Id
            };
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<AllUserCommentsViewModel>> AllCommentsAsync()
        {
            var comments = await repository.AllAsReadOnly<UserComment>()
                .Select(x => new AllUserCommentsViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReceivingCommentUserName = x.Receiver.FirstName + " " + x.Receiver.LastName,
                    SendingCommentUserName = x.Sender.FirstName + " " + x.Sender.LastName,
                }).ToListAsync();
            return comments;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<UserComment>()
                .AnyAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<AllCommentAboutUserFromOtherUsers>> GetAllCommentAboutUserFromOtherUsers(string userId)
        {
            var comments = await repository.AllAsReadOnly<UserComment>()
                .Where(x => x.ReceivingCommentUserId == userId)
                .Select(x => new AllCommentAboutUserFromOtherUsers()
                {
                    Id = x.Id,
                    Content = x.Content,
                    SendingCommentUserName = x.Sender.FirstName + " " + x.Sender.LastName,
                    UserId = x.SendingCommentUserId
                }).ToListAsync();
            return comments;
        }
        public async Task<IEnumerable<AllUserCommentForOtherUsers>> GetAllUserCommentsForOtherUsers(string userId)
        {
            var comments = await repository.AllAsReadOnly<UserComment>()
                .Where(x => x.SendingCommentUserId == userId)
                .Select(x => new AllUserCommentForOtherUsers()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReceivingCommentUserName = x.Receiver.FirstName + " " + x.Receiver.LastName,
                    UserId = x.ReceivingCommentUserId
                }).ToListAsync();
            return comments;
        }
        public async Task<DeleteUserCommentViewModel> GetUserCommentForDeleteAsync(int id)
        {
            var comment = await repository.AllAsReadOnly<UserComment>()
               .Where(x => x.Id == id)
               .Select(x => new DeleteUserCommentViewModel()
               {
                   Id = x.Id,
                   Content = x.Content,
                   SendingCommentUserName = x.Sender.FirstName + " " + x.Sender.LastName,
               })
               .FirstAsync();
            return comment;
        }
        public async Task RemoveAsync(int id)
        {
            var comment = await repository.GetByIdAsync<UserComment>(id);
            if (comment != null)
            {
                repository.Delete<UserComment>(comment);
                await repository.SaveChangesAsync();
            }
        }
        public async Task<bool> UserExistAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(x=> x.Id == id);
        }
    }
}
