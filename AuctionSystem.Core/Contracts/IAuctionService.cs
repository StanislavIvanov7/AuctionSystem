using AuctionSystem.Core.Enumeration;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Infrastructure.Data.Models;
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

        Task<bool> ConditionExistAsync(int id);

        Task AddAsync(AuctionFormViewModel model, string userId);

        Task<AuctionFormViewModel> GetAuctionForEditAsync(int id);

        Task<ModeratorAuctionFormViewModel> GetModeratorAuctionForEditAsync(int id);

        Task EditAsync(int id, AuctionFormViewModel model);

        Task ModeratorEditAsync(int id, ModeratorAuctionFormViewModel model);

        //Task EditConditionAsync(int id, AuctionFormViewModel model);

        Task<Auction> GetAuctionByNameAsync(string name);

        Task<Auction> GetAuctionByIdAsync(int id);

        Task AddImagesAsync(Auction auction,List<string> imageUrls);

    }
}
