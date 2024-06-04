using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Models.Bidding;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AuctionSystem.Core.Services
{
    public class BiddingService : IBiddingService
    {
        private readonly IRepository repository;

        public BiddingService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddBiddingAsync(BiddingFormViewModel model, string userId)
        {
            Bidding bidding = new Bidding()
            {
                
                AuctionId = model.Id,
                BuyerId = userId,
                DateAndTimeOfBidding = DateTime.Now,
                Price = model.LastPrice


            };

            await repository.AddAsync(bidding);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> AuctionExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Auction>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            var auction = await repository.All<Auction>()
                .FirstAsync(x => x.Id == id);
            return auction;
        }

        public async Task<bool> IsActiveAsync(int id)
        {
            var auction = await GetAuctionByIdAsync(id);
          
            if(auction.ConditionId == 4)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsValidAsync(int id)
        { 
            var auction = await GetAuctionByIdAsync (id);
            var days = auction.BiddingPeriodInDays;
            var finalDateTime = auction.StartingAuctionDateTime.AddDays(days);


            if (finalDateTime < DateTime.Now)
            {

                return false;

            }

            return true;
        }

        public async Task SetNewValuesForAuctionAsync(BiddingFormViewModel model, int id)
        {
            var auction = await GetAuctionByIdAsync(id);
            auction.LastPrice = model.LastPrice;
            auction.BiddingCount += 1;
            await repository.SaveChangesAsync();
        }
    }
}
