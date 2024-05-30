using AuctionSystem.Core.Enumeration;
using AuctionSystem.Core.Models.Auction;

namespace AuctionSystem.Core.Contracts
{
    public interface IAuctionService
    {
        Task<AuctionQueryViewModel> AllAuctionAsync(
       string? category = null,
       string? searchTerm = null,
       AuctionSorting sorting = AuctionSorting.LastActiveAuction,
       int currentPage = 1,
       int housesPerPage = 1);

        Task<IEnumerable<string>> AllConditionNamesAsync();

        Task<bool> ExistAsync(int id);

        Task<DetailsAuctionViewModel> DetailsAuctionAsync(int id);

        Task<IEnumerable<AllAuctionConditionsViewModel>> GetAuctionConditionsAsync();
    }
}
