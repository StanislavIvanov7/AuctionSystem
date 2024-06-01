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

        public async Task AddAsync(AuctionFormViewModel model, string userId)
        {
            Auction auction = new Auction()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                BiddingPeriodInDays = model.BiddingPeriodInDays,
                ConditionId = model.ConditionId,
                InitialPrice = model.InitialPrice,
                SellerId = userId,
                MinBiddingStep = model.MinBiddingStep,


            };

            await repository.AddAsync(auction);
            await repository.SaveChangesAsync();
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
                    ImageUrl = x.Images.Where(x=>x.AuctionId == x.Auction.Id).ToList(),


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

        public async Task<bool> ConditionExistAsync(int id)
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .AnyAsync(x=>x.Id == id);
        }

        public async Task<DetailsAuctionViewModel> DetailsAuctionAsync(int id)
        {
            var auction = await repository.AllAsReadOnly<Auction>()
              .Where(x => x.Id == id)
              .Select(x => new DetailsAuctionViewModel()
              {
                  Id = x.Id,
                  Name = x.Name,
                  InitialPrice = x.InitialPrice,
                  Description = x.Description,
                  Condition = x.Condition.Name,
                  Seller = x.Seller.Email,
                  LastBuyer = x.LastBuyer.Email,
                  BiddingCount = x.BiddingCount,
                  LastPrice = x.LastPrice,
                  MinBiddingStep = x.MinBiddingStep,
                  BiddingPeriodInDays = x.BiddingPeriodInDays
                  



              }).FirstAsync();

            return auction;
        }

        public async Task<bool> ExistAsync(int id)
        {
           return await repository.AllAsReadOnly<Auction>()
                .AnyAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<AllAuctionConditionsViewModel>> GetAuctionConditionsAsync()
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .Select(x => new AllAuctionConditionsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
        }
    }
}
