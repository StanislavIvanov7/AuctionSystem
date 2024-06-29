using AuctionSystem.Core.Models.Bidding;
using AuctionSystem.Infrastructure.Data.Models;

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
