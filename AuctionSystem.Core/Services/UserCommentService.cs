using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Models.UserComment;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ReceivingCommentUserName = x.User2.FirstName + " " + x.User2.LastName,
                    SendingCommentUserName = x.User.FirstName + " " + x.User.LastName,

                }).ToListAsync();

            return comments;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<UserComment>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<DeleteUserCommentViewModel> GetUserCommentForDeleteAsync(int id)
        {
            var comment = await repository.AllAsReadOnly<UserComment>()
               .Where(x => x.Id == id)
               .Select(x => new DeleteUserCommentViewModel()
               {
                   Id = x.Id,
                   Content = x.Content,
                   SendingCommentUserName = x.User.FirstName + " " + x.User.LastName,

               })
               .FirstAsync();

            return comment;
        }

        public async Task<bool> UserExistAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(x=> x.Id == id);
        }
    }
}
