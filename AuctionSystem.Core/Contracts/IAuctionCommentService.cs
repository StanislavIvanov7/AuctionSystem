using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Contracts
{
    public interface IAuctionCommentService
    {
        //Task<IEnumerable<AuctionNameViewModel>> GetAuctionNamesAsync();

        Task<bool> AuctionExistAsync(int id);

        Task AddAsync(AuctionCommentFormViewModel model,string userId);
    }
}
