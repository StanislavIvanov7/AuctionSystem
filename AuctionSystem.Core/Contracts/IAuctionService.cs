using AuctionSystem.Core.Enumeration;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Models;

namespace AuctionSystem.Core.Contracts
{
    public interface IAuctionService
    {
        Task<AuctionQueryViewModel> AllAuctionAsync(
       string? category = null,
       string? searchTerm = null,
       AuctionSorting? sorting = null,
       int currentPage = 1,
       int auctionPerPage = 1);

        Task<AuctionQueryViewModel> AllAuctionAsync(
       string? searchTerm = null,
       AuctionSorting sorting = AuctionSorting.LastActiveAuction,
       int currentPage = 1,
       int auctionPerPage = 1);

        Task<IEnumerable<string>> AllConditionNamesAsync();

        Task<bool> ExistAsync(int id);

        Task<DetailsAuctionViewModel> DetailsAuctionAsync(int id);

        Task<IEnumerable<AllAuctionConditionsViewModel>> GetAuctionConditionsAsync();

        Task<IEnumerable<AllAuctionConditionsViewModel>> GetOnlyTwoAuctionConditionsAsync();

        Task<bool> ConditionExistAsync(int id);

        Task SetConditionToFinish(int auctionId);

        Task TerminateAuction(int auctionId);

        Task<int> AddAsync(AuctionFormViewModel model, string userId);

        Task<AuctionFormViewModel> GetAuctionForEditAsync(int id);

        Task<ModeratorAuctionFormViewModel> GetModeratorAuctionForEditAsync(int id);

        Task EditAsync(int id, AuctionFormViewModel model);

        Task ModeratorEditAsync(int id, ModeratorAuctionFormViewModel model);

        Task<Auction> GetAuctionByNameAsync(string name);

        Task<Auction> GetAuctionByIdAsync(int id);

        Task AddImagesAsync(Auction auction,string image,List<string> imageUrls);

        Task<IEnumerable<MyAuctionViewModel>> GetAllAuctionsForUser(string userId);

        Task<bool> UserExistAsync(string id);
    }
}
