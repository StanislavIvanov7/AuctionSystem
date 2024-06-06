using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.Bidding;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Contracts
{
    public interface IBiddingService
    {
        Task<bool> AuctionExistAsync(int id);

        Task<Auction> GetAuctionByIdAsync(int id);

        Task<bool> IsValidAsync(int id);

        Task<bool> IsActiveAsync(int id);

        Task AddBiddingAsync(BiddingFormViewModel model, string userId);

        Task SetNewValuesForAuctionAsync(BiddingFormViewModel model, int id,string userId);

        Task<IEnumerable<AllBiddingsViewModel>> AllBiddingsAsync();

        Task<IEnumerable<AllBiddingsViewModel>> AllBiddingsForAuctionAsync(int auctionId);
    }
}
