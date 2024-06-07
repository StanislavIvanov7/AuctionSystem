using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Models.User;
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
    public class AuctionCommentService : IAuctionCommentService
    {
        private readonly IRepository repository;

        public AuctionCommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(AuctionCommentFormViewModel model,string userId)
        {
            AuctionComment comment = new AuctionComment()
            {
                AuctionId = model.Id,
                Content = model.Content,
                UserId = userId
                


            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCommentsViewModel>> AllCommentsAsync()
        {
            var comments = await repository.AllAsReadOnly<AuctionComment>()
                .Select(x => new AllCommentsViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    AuctionImageUrl = x.Auction.Images.First().ImageUrl,
                    AuctionName = x.Auction.Name

                }).ToListAsync();

            return comments;
        }

        public async Task<IEnumerable<AllCommentsViewModel>> AllCommentsForAuctionAsync(int id)
        {
            var comments = await repository.AllAsReadOnly<AuctionComment>()
                .Where(x=>x.AuctionId == id)
                .Select(x => new AllCommentsViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    AuctionImageUrl = x.Auction.Images.First().ImageUrl,
                    AuctionName = x.Auction.Name

                }).ToListAsync();

            return comments;
        }

        public async Task<bool> AuctionExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Auction>()
                .AnyAsync(x=>x.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<AuctionComment>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AllCommentsViewModel>> GetAllAuctionCommentsFromUser(string id)
        {
            var comments = await repository.AllAsReadOnly<AuctionComment>()
                 .Where(x => x.UserId == id)
                 .Select(x => new AllCommentsViewModel()
                 {
                     Id = x.AuctionId,
                     Content = x.Content,
                     AuctionImageUrl = x.Auction.Images.First().ImageUrl,
                     AuctionName = x.Auction.Name

                 }).ToListAsync();

            return comments;
        }

        public async Task<DeleteCommentViewModel> GetCommentForDeleteAsync(int id)
        {
            var comment = await repository.AllAsReadOnly<AuctionComment>()
               .Where(x => x.Id == id)
               .Select(x => new DeleteCommentViewModel()
               {
                   Id = x.Id,
                   Content = x.Content,
                   ImageUrl = x.Auction.Images.First().ImageUrl,
                   AuctionName = x.Auction.Name

               })
               .FirstAsync();

            return comment;
        }

        public async Task RemoveAsync(int id)
        {
            var comment = await repository.GetByIdAsync<AuctionComment>(id);

            if (comment != null)
            {
                repository.Delete<AuctionComment>(comment);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> UserExistAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(x => x.Id == id);
        }

        //public async Task<IEnumerable<AuctionNameViewModel>> GetAuctionNamesAsync()
        //{
        //    return await repository.AllAsReadOnly<Auction>()
        //        .Select(x => new AuctionNameViewModel
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //        }).ToListAsync();
        //}
    }
}
