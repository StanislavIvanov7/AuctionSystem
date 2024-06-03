using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
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

        public async Task<bool> AuctionExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Auction>()
                .AnyAsync(x=>x.Id == id);
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
