using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            var fixedDate = new DateTime(2024, 5, 24);

            auction = new Auction()
            {
                Id = 1,
                Name = "Car auction",
                Description = "Mercedes C200 2018 car for sale with a starting price of 12,000lv and a minimum bid of BGN 100.On actual kilometers without any remarks.",
                InitialPrice = 12000,
                MinBiddingStep = 100,
                BiddingPeriodInDays = 5,
                ConditionId = 5,
                SellerId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                LastPrice = 20000,
                LastBuyerId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                BiddingCount = 1,
                StartingAuctionDateTime = fixedDate,
            };
            auctions.Add(auction);

            return auctions;
        }
    }
}
