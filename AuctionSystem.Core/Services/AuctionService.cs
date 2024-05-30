using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Enumeration;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IRepository repository;

        public AuctionService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<AuctionQueryViewModel> AllAuctionAsync(
            string? condition,
            string? searchTerm,
            AuctionSorting sorting = AuctionSorting.LastActiveAuction,
            int currentPage = 1,
            int auctionPerPage = 1)
        {
            var auctionToShow = repository.All<Auction>();

            if (condition != null)
            {
                auctionToShow = auctionToShow.Where(x => x.Condition.Name == condition);

            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                auctionToShow = auctionToShow.Where(x => (x.Name.ToLower().Contains(normalizedSearchTerm) ||
                                                           x.Description.ToLower().Contains(normalizedSearchTerm)));

            }

            auctionToShow = sorting switch
            {
                AuctionSorting.MinPriceAuction => auctionToShow
                    .OrderBy(h => h.LastPrice),
                    AuctionSorting.AuctionWithTheMostBids => auctionToShow
                    .OrderByDescending(x=>x.BiddingCount),
                _ => auctionToShow
                    .OrderByDescending(x=>x.Condition.Name == "active")
            };

            var auction = await auctionToShow
                .Skip((currentPage - 1) * auctionPerPage)
                .Take(auctionPerPage)
                .Select(x => new AllAuctionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,


                })
                .ToListAsync();

            int totalAuction = await auctionToShow.CountAsync();

            return new AuctionQueryViewModel()
            {
                Auction = auction,
                TotalAuctionCount = totalAuction
            };
        }

        public async Task<IEnumerable<string>> AllConditionNamesAsync()
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .Select(x=>x.Name)
                .ToListAsync();
        }
    }
}
