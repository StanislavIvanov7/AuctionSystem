using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasData(SeedAuction());
        }

        private List<Auction> SeedAuction()
        {
            List<Auction> auctions = new List<Auction>();

            Auction auction;

            auction = new Auction()
            {
                Id = 1,
                Name = "Car auction",
                Description = "Mercedes C200 2018 car for sale with a starting price of 12,000lv and a minimum bid of BGN 100.On actual kilometers without any remarks.",
                InitialPrice = 12000,
                MinBiddingStep = 100,
                BiddingPeriodInDays = 5,
                ConditionId = 5,
                SellerId = "ea9548dc-aac6-49b5-abe1-561136ac48c7",
                LastPrice = 20000,
                LastBuyerId = "39fb9235-83a6-4bb9-9236-490a99f6bb83",

            };

            auctions.Add(auction);
           
            return auctions;

        }
    }
}
